using MateriaGris.Ecommerce.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MateriaGris.Ecommerce.Infrastructure.Persistences.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetAsync(string employeeId);
        Task<bool> InsertAsync(Employee employee);
        Task<bool> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(string employeeId);
    }
}
