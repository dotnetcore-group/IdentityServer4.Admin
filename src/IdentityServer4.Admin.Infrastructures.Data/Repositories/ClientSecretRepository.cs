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
    public class ClientSecretRepository : Repository<ClientSecret>, IClientSecretRepository
    {
        public ClientSecretRepository(IDS4DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ClientSecret>> FindByClientIdAsync(string clientId)
        {
            return await DbSet.Where(s => s.Client.ClientId == clientId).ToListAsync();
        }
    }
}
