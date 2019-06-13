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
    public class ClientPropertyRepository : Repository<ClientProperty>, IClientPropertyRepository
    {
        public ClientPropertyRepository(IDS4DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ClientProperty>> FindByClientIdAsync(string clientId)
        {
            return await DbSet.Where(p => p.Client.ClientId == clientId).ToListAsync();
        }
    }
}
