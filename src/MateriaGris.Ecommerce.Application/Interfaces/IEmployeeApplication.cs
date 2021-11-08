using MateriaGris.Ecommerce.Application.Commons;
using MateriaGris.Ecommerce.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MateriaGris.Ecommerce.Application.Interfaces
{
    public interface IEmployeeApplication
    {
        Task<Response<IEnumerable<EmployeeDto>>> GetAllAsync();
        Task<Response<EmployeeDto>> GetAsync(string employeeId);
        Task<Response<bool>> InsertAsync(EmployeeDto employeeDto);
        Task<Response<bool>> UpdateAsync(EmployeeDto employeeDto);
        Task<Response<bool>> DeleteAsync(string employeeId);
    }
}
