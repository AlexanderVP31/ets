using FluentValidation;
using MateriaGris.Ecommerce.Application.Dtos;

namespace MateriaGris.Ecommerce.Application.Validator
{
    public class AccountDtoValidator : AbstractValidator<AccountDto>
    {
        public AccountDtoValidator()
        {
            RuleFor(x => x.Client).NotEmpty().NotNull();
            RuleFor(x => x.Secret).NotEmpty().NotNull();
        }
    }
}
