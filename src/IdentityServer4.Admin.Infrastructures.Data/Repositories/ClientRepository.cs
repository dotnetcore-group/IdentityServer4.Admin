using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Infrastructures.Data.Database;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Data.Repositories
{
    using IdentityServer4.EntityFramework.Entities;
    using System.Linq;

    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(IDS4DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> ExistedAsync(string clientId)
        {
            return await DbSet.AnyAsync(c => c.ClientId == clientId);
        }

        public async Task<Client> FindByClientIdAsync(string clientId)
        {
            return await DbSet.FirstOrDefaultAsync(c => c.ClientId == clientId);
        }

        public async Task<Client> FindByClientIdWithNoTrackingAsync(string clientId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.ClientId == clientId);
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

        public async Task UpdateWithChildrensAsync(Client entity)
        {
            await RemoveClientRelationsAsync(entity);
            await UpdateAsync(entity);
        }

        private async Task RemoveClientRelationsAsync(Client client)
        {
            var scopes = await DbContext.ClientScopes.Where(s => s.ClientId == client.Id).ToListAsync();
            DbContext.ClientScopes.RemoveRange(scopes);

            var grantTypes = await DbContext.ClientGrantTypes.Where(g => g.ClientId == client.Id).ToListAsync();
            DbContext.ClientGrantTypes.RemoveRange(grantTypes);

            var redirectUris = await DbContext.ClientRedirectUris.Where(r => r.ClientId == client.Id).ToListAsync();
            DbContext.ClientRedirectUris.RemoveRange(redirectUris);

            var corsOrigins = await DbContext.ClientCorsOrigins.Where(o => o.ClientId == client.Id).ToListAsync();
            DbContext.ClientCorsOrigins.RemoveRange(corsOrigins);

            var logoutUris = await DbContext.ClientPostLogoutRedirectUris.Where(p => p.ClientId == client.Id).ToListAsync();
            DbContext.ClientPostLogoutRedirectUris.RemoveRange(logoutUris);

            var idps = await DbContext.ClientIdPRestrictions.Where(i => i.ClientId == client.Id).ToListAsync();
            DbContext.ClientIdPRestrictions.RemoveRange(idps);
        }
    }
}
