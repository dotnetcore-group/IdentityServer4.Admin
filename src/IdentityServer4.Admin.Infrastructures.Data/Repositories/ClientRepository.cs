using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Infrastructures.Data.Database;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Data.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(IDS4DbContext dbContext) : base(dbContext)
        {
        }

        public Task<Client> GetClient(string clientId)
        {
            return DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClientId == clientId);
        }
    }
}
