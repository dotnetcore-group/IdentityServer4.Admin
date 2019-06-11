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

        public async Task<Client> GetClientAsync(string clientId)
        {
            return await DbSet
                .AsNoTracking()
                .Include(c => c.AllowedCorsOrigins)
                .Include(c => c.AllowedGrantTypes)
                .Include(c => c.AllowedScopes)
                .Include(c => c.Claims)
                .Include(c => c.ClientSecrets)
                .Include(c => c.RedirectUris)
                .Include(c => c.PostLogoutRedirectUris)
                .Include(c => c.IdentityProviderRestrictions)
                .Include(c => c.Properties)
                .FirstOrDefaultAsync(c => c.ClientId == clientId);
        }
    }
}
