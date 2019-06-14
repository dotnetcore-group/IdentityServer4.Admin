using IdentityServer4.Admin.Domain.Entities;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Infrastructures.Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Data.Repositories
{
    public class StartupRepository : Repository<Startup>, IStartupRepository
    {
        public StartupRepository(IDS4DbContext dbContext) : base(dbContext)
        {
        }

        public void SetInitialized()
        {
            var startup = FirstOrDefault(c => true);
            if (startup != null)
            {
                startup.Initialized = true;
                startup.InitializedDate = DateTime.UtcNow;

                DbSet.Update(startup);
            }
            else
            {
                startup = new Startup
                {
                    Initialized = true,
                    InitializedDate = DateTime.UtcNow
                };
                DbSet.Add(startup);
            }

            SaveChanges();
        }
    }
}
