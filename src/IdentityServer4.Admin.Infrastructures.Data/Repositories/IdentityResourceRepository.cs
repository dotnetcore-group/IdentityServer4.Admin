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
    public class IdentityResourceRepository : Repository<IdentityResource>, IIdentityResourceRepository
    {
        public IdentityResourceRepository(IDS4DbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IdentityResource> FindByNameAsync(string name)
        {
            return await DbSet
                .AsNoTracking()
                .Include(r => r.Properties)
                .Include(r => r.UserClaims)
                .FirstOrDefaultAsync(r => r.Name == name);
        }

        public async Task UpdateWithChildrensAsync(IdentityResource resource)
        {
            var claims = await DbContext.IdentityClaims.Where(c => c.IdentityResourceId == resource.Id).ToListAsync();
            DbContext.IdentityClaims.RemoveRange(claims);

            var properties = await DbContext.IdentityResourceProperties.Where(r => r.IdentityResourceId == resource.Id).ToListAsync();
            DbContext.IdentityResourceProperties.RemoveRange(properties);

            await UpdateAsync(resource);
        }
    }
}
