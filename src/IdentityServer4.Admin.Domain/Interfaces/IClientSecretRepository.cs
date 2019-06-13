using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.Interfaces
{
    public interface IClientSecretRepository : IRepository<ClientSecret>, IAsyncRepository<ClientSecret>
    {
        Task<IEnumerable<ClientSecret>> FindByClientIdAsync(string clientId);
    }
}
