using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Infrastructures.Data.Database;
using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Data.Repositories
{
    public class IdentityResourceRepository : Repository<IdentityResource>, IIdentityResourceRepository
    {
        public IdentityResourceRepository(IDS4DbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
