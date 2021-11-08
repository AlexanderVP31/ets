using AutoMapper;
using MateriaGris.Ecommerce.Application.Commons;
using MateriaGris.Ecommerce.Application.Dtos;
using MateriaGris.Ecommerce.Application.Interfaces;
using MateriaGris.Ecommerce.Application.Validator;
using MateriaGris.Ecommerce.Domain.Entities;
using MateriaGris.Ecommerce.Infrastructure.Persistences.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace MateriaGris.Ecommerce.Application.Services
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly AccountDtoValidator _accountDtoValidator;

        public AccountApplication(IAccountRepository accountRepository, IMapper mapper, IConfiguration configuration, AccountDtoValidator accountDtoValidator)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _configuration = configuration;
            _accountDtoValidator = accountDtoValidator;
        }

        public async Task<Response<bool>> InsertAsync(AccountDto accountDto)
        {
            var response = new Response<bool>();
            try
            {
                var account = _mapper.Map<Account>(accountDto);
                account.Secret = BC.HashPassword(accountDto.Secret);

                response.Data = await _accountRepository.InsertAsync(account);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
                else
                {
                    response.Message = "Registro Fallido!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<string>> TokenAsync(AccountDto accountDto)
        {
            var response = new Response<string>();
            try
            {
                var validationResult = _accountDtoValidator.Validate(accountDto);

                if (!validationResult.IsValid)
                {
                    response.Message = "Errores de Validación";
                    response.Errors = validationResult.Errors;
                    return response;
                }
                
                var account = await _accountRepository.GetAsync(accountDto.Client);
                if (account is not null)
                {
                    if (BC.Verify(accountDto.Secret, account.Secret))
                    {
                        response.Data = GenerateToken(account);
                        response.IsSuccess = true;
                        response.Message = "Token Exitoso!!!";
                        return response;
                    }
                }
                else
                {
                    response.Message = "Cuenta No Valida!!!";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;                
            }

            return response;
        }

        private string GenerateToken(Account account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, account.Abbreviation),
                new Claim(JwtRegisteredClaimNames.FamilyName, account.Company),
                new Claim(JwtRegisteredClaimNames.GivenName, account.Client),
                new Claim(JwtRegisteredClaimNames.UniqueName, account.AccountId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, Guid.NewGuid().ToString(), ClaimValueTypes.Integer64),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:Expires"])),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
