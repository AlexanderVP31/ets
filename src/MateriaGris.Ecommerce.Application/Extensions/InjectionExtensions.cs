using FluentValidation;
using MateriaGris.Ecommerce.Application.Interfaces;
using MateriaGris.Ecommerce.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MateriaGris.Ecommerce.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);

            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<IAccountApplication, AccountApplication>();
            services.AddScoped<IProductApplication, ProductApplication>();
            services.AddScoped<IEmployeeApplication, EmployeeApplication>();

            // Fluent Validation Configurations
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Auto Mapper Configurations
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
