using MateriaGris.Ecommerce.Domain.Entities;
using MateriaGris.Ecommerce.Infrastructure.Persistences.Contexts;
using MateriaGris.Ecommerce.Infrastructure.Persistences.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace MateriaGris.Ecommerce.Infrastructure.Persistences.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public EmployeeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "EmployeesList";

                var employees = await connection.QueryAsync<Employee>(query, commandType: CommandType.StoredProcedure);
                return employees;
            }
        }

        public async Task<Employee> GetAsync(string employeeId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "EmployeesGetById";
                var parameters = new DynamicParameters();
                parameters.Add("EmployeeId", employeeId);

                var employee = await connection.QuerySingleAsync<Employee>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return employee;
            }
        }

        public async Task<bool> InsertAsync(Employee employee)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "EmployeesInsert";
                var parameters = new DynamicParameters();
               //parameters.Add("EmployeeId", employee.EmployeeId);
                parameters.Add("LastName", employee.LastName);
                parameters.Add("FirstName", employee.FirstName);
                parameters.Add("Title", employee.Title);
                parameters.Add("TitleOfCourtesy", employee.TitleOfCourtesy);
                parameters.Add("BirthDate", employee.BirthDate);
                parameters.Add("HireDate", employee.HireDate);
                parameters.Add("Address", employee.Address);
                parameters.Add("City", employee.City);
                parameters.Add("Region", employee.Region);
                parameters.Add("PostalCode", employee.PostalCode);
                parameters.Add("Country", employee.Country);
                parameters.Add("HomePhone", employee.HomePhone);
                parameters.Add("Extension", employee.Extension);
                parameters.Add("Notes", employee.Notes);
                parameters.Add("ReportsTo", employee.ReportsTo);
                parameters.Add("PhotoPath", employee.PhotoPath);
                parameters.Add("DocumentNumber", employee.DocumentNumber);
                parameters.Add("Salary", employee.Salary);
                parameters.Add("Age", employee.Age);
                parameters.Add("Profile", employee.Profile);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "EmployeesUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("EmployeeId", employee.EmployeeId);
                parameters.Add("LastName", employee.LastName);
                parameters.Add("FirstName", employee.FirstName);
                parameters.Add("Title", employee.Title);
                parameters.Add("TitleOfCourtesy", employee.TitleOfCourtesy);
                parameters.Add("BirthDate", employee.BirthDate);
                parameters.Add("HireDate", employee.HireDate);
                parameters.Add("Address", employee.Address);
                parameters.Add("City", employee.City);
                parameters.Add("Region", employee.Region);
                parameters.Add("PostalCode", employee.PostalCode);
                parameters.Add("Country", employee.Country);
                parameters.Add("HomePhone", employee.HomePhone);
                parameters.Add("Extension", employee.Extension);
                parameters.Add("Notes", employee.Notes);
                parameters.Add("ReportsTo", employee.ReportsTo);
                parameters.Add("PhotoPath", employee.PhotoPath);
                parameters.Add("DocumentNumber", employee.DocumentNumber);
                parameters.Add("Salary", employee.Salary);
                parameters.Add("Age", employee.Age);
                parameters.Add("Profile", employee.Profile);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string employeeId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "EmployeesDelete";
                var parameters = new DynamicParameters();
                parameters.Add("EmployeeId", employeeId);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
