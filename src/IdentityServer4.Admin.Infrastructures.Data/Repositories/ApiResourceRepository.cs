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
    public class ApiResourceRepository : Repository<ApiResource>, IApiResourceRepository
    {
        public ApiResourceRepository(IDS4DbContext dbContext)
            : base(dbContext)
        {
        }

        public Task<ApiResource> FindByNameAsync(string name) => DbSet.Include(a => a.UserClaims).FirstOrDefaultAsync(a => a.Name == name);

        public Task<List<ApiResource>> GetApiResourcesAsync() => DbSet.AsNoTracking().Include(a => a.UserClaims).ToListAsync();
    }
}
