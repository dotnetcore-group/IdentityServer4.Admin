using Microsoft.AspNetCore.Hosting;
using IdentityServer4.Admin.BuildingBlock;
using System;
using IdentityServer4.Admin.Infrastructures.Data.Database;

namespace IdentityServer4.SSO.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost MigrationAndSeedDataDB(this IWebHost webHost)
        {
            webHost.MigrateDbContext<IS4DbContext>(EnsureSeedIS4Data)
                .MigrateDbContext<ApplicationIdentityDbContext>(EnsureSeedIdentityData);

            return webHost;
        }

        private static void EnsureSeedIdentityData(ApplicationIdentityDbContext context, IServiceProvider sp)
        {
            
        }

        private static void EnsureSeedIS4Data(IS4DbContext context, IServiceProvider sp)
        {

        }
    }
}
