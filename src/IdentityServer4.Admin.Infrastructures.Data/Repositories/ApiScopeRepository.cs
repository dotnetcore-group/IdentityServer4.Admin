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
    public class ApiScopeRepository : Repository<ApiScope>, IApiScopeRepository
    {
        public ApiScopeRepository(IDS4DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ApiScope>> FindByApiResourceNameAsync(string name)
            => await DbSet.Include(s => s.UserClaims).Where(s => s.ApiResource.Name == name).ToListAsync();
    }
}
