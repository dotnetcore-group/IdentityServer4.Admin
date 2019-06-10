using IdentityServer4.EntityFramework.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>, IAsyncRepository<Client>
    {
        Task<Client> GetClient(string clientId);
    }
}
