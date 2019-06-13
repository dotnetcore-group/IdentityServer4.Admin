using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Infrastructures.Data.Database;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Data.Repositories
{
    public class ClientClaimRepository : Repository<ClientClaim>, IClientClaimRepository
    {
        public ClientClaimRepository(IDS4DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ClientClaim>> FindByClientIdAsync(string clientId)
        {
            return await DbSet.Where(c => c.Client.ClientId == clientId).ToListAsync();
        }
    }
}
