using Microsoft.VisualStudio.TestTools.UnitTesting;
using MateriaGris.Ecommerce.WebApi;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using MateriaGris.Ecommerce.Application.Interfaces;
using MateriaGris.Ecommerce.Application.Dtos;
using System.Threading.Tasks;

namespace MateriaGris.Ecommerce.Test
{
    [TestClass]
    public class CustomerApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();

            _configuration = builder.Build();
            _configuration.GetConnectionString("MateriaGrisConnection");

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        //[TestMethod]
        //public async Task GetAsync_CuandoSeEnviaValoresNulosOVacios_ErroresDeValidacion()
        //{
        //    using var scope = _scopeFactory.CreateScope();
        //    var context = scope.ServiceProvider.GetService<ICustomerApplication>();

        //    // Arrange
        //    context.

        //    // Act


        //    // Assert

        //}

        //[TestMethod]
        //public async Task GetAsync_CuandoSeEnviaValoresCorrectos_ConsultaExitosa()
        //{
        //    using var scope = _scopeFactory.CreateScope();
        //    var context = scope.ServiceProvider.GetService<ICustomerApplication>();

        //    // Arrange


        //    // Act


        //    // Assert

        //}

    }
}
