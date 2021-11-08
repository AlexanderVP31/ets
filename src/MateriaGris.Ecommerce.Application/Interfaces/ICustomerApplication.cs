using MateriaGris.Ecommerce.Application.Commons;
using MateriaGris.Ecommerce.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MateriaGris.Ecommerce.Application.Interfaces
{
    public interface ICustomerApplication
    {
        Task<Response<IEnumerable<CustomerDto>>> GetAllAsync();
        Task<Response<CustomerDto>> GetAsync(string customerId);
        Task<Response<bool>> InsertAsync(CustomerDto customerDto);
        Task<Response<bool>> UpdateAsync(CustomerDto customerDto);
        Task<Response<bool>> DeleteAsync(string customerId);
    }
}
