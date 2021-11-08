using MateriaGris.Ecommerce.Application.Commons;
using MateriaGris.Ecommerce.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MateriaGris.Ecommerce.Application.Interfaces
{
    public interface IProductApplication
    {
        Task<Response<IEnumerable<ProductDto>>> GetAllAsync();
        Task<Response<ProductDto>> GetAsync(string productId);  
        Task<Response<bool>> InsertAsync(ProductDto productDto);
        Task<Response<bool>> UpdateAsync(ProductDto productDto);
        Task<Response<bool>> DeleteAsync(string productId);
    }
}
