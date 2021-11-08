using MateriaGris.Ecommerce.Infrastructure.Persistences.Contexts;
using MateriaGris.Ecommerce.Infrastructure.Persistences.Interfaces;
using MateriaGris.Ecommerce.Infrastructure.Persistences.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MateriaGris.Ecommerce.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
