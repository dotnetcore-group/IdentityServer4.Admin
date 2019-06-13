using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.Interfaces
{
    using IdentityServer4.EntityFramework.Entities;
    public interface IClientRepository : IRepository<Client>, IAsyncRepository<Client>
    {
        Task<Client> GetClientAsync(string clientId);
        Task<bool> ExistedAsync(string clientId);
        Task<Client> FindByClientIdAsync(string clientId);
        Task UpdateWithChildrensAsync(Client entity);
    }
}
