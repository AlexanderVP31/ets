using MateriaGris.Ecommerce.Domain.Entities;
using MateriaGris.Ecommerce.Infrastructure.Persistences.Contexts;
using MateriaGris.Ecommerce.Infrastructure.Persistences.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace MateriaGris.Ecommerce.Infrastructure.Persistences.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ProductRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "ProductsList";

                var products = await connection.QueryAsync<Product>(query, commandType: CommandType.StoredProcedure);
                return products;
            }
        }

        public async Task<Product> GetAsync(string productId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "ProductsGetById";
                var parameters = new DynamicParameters();
                parameters.Add("ProductId", productId);

                var product = await connection.QuerySingleAsync<Product>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return product;
            }
        }

        public async Task<bool> InsertAsync(Product product)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "ProductsInsert";
                var parameters = new DynamicParameters();
                parameters.Add("ProductName", product.ProductName);
                parameters.Add("SupplierID", product.SupplierID);
                parameters.Add("CategoryID", product.CategoryID);
                parameters.Add("QuantityPerUnit", product.QuantityPerUnit);
                parameters.Add("UnitPrice", product.UnitPrice);
                parameters.Add("UnitsInStock", product.UnitsInStock);
                parameters.Add("UnitsOnOrder", product.UnitsOnOrder);
                parameters.Add("ReorderLevel", product.ReorderLevel);
                parameters.Add("Discontinued", product.Discontinued);
               
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "ProductsUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("ProductID", product.ProductID);
                parameters.Add("ProductName", product.ProductName);
                parameters.Add("SupplierID", product.SupplierID);
                parameters.Add("CategoryID", product.CategoryID);
                parameters.Add("QuantityPerUnit", product.QuantityPerUnit);
                parameters.Add("UnitPrice", product.UnitPrice);
                parameters.Add("UnitsInStock", product.UnitsInStock);
                parameters.Add("UnitsOnOrder", product.UnitsOnOrder);
                parameters.Add("ReorderLevel", product.ReorderLevel);
                parameters.Add("Discontinued", product.Discontinued);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string productId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "ProductsDelete";
                var parameters = new DynamicParameters();
                parameters.Add("ProductId", productId);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

       
    }
}
