using MateriaGris.Ecommerce.Application.Dtos;
using MateriaGris.Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MateriaGris.Ecommerce.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountApplication _accountApplication;

        public AccountController(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }
        [AllowAnonymous]
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] AccountDto accountDto)
        {
            if (accountDto is null)
                return BadRequest();

            var response = await _accountApplication.InsertAsync(accountDto);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        [AllowAnonymous]
        [HttpPost("TokenAsync")]
        public async Task<IActionResult> TokenAsync([FromBody] AccountDto accountDto)
        {
            if (accountDto is null)
                return BadRequest();

            var response = await _accountApplication.TokenAsync(accountDto);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
