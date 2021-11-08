using MateriaGris.Ecommerce.Domain.Entities;
using System.Threading.Tasks;

namespace MateriaGris.Ecommerce.Infrastructure.Persistences.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetAsync(string client);
        Task<bool> InsertAsync(Account account);
    }
}