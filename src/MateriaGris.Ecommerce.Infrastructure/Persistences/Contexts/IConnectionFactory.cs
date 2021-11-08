using System.Data;

namespace MateriaGris.Ecommerce.Infrastructure.Persistences.Contexts
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
