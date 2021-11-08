using MateriaGris.Ecommerce.Application.Commons;
using MateriaGris.Ecommerce.Application.Dtos;
using System.Threading.Tasks;

namespace MateriaGris.Ecommerce.Application.Interfaces
{
    public interface IAccountApplication
    {
        Task<Response<bool>> InsertAsync(AccountDto accountDto);
        Task<Response<string>> TokenAsync(AccountDto accountDto);
    }
}