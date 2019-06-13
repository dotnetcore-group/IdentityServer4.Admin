using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.Interfaces
{
    public interface IClientClaimRepository : IRepository<ClientClaim>, IAsyncRepository<ClientClaim>
    {
        Task<IEnumerable<ClientClaim>> FindByClientIdAsync(string clientId);
    }
}
