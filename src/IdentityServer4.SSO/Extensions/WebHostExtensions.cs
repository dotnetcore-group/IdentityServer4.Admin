using Microsoft.AspNetCore.Hosting;
using IdentityServer4.Admin.BuildingBlock;
using System;
using IdentityServer4.Admin.Infrastructures.Data.Database;
using IdentityServer4.Admin.Identity;
using IdentityServer4.Admin.Data.Database;

namespace IdentityServer4.SSO.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost MigrationAndSeedDataDB(this IWebHost webHost)
        {
            webHost.MigrateDbContext<IDS4DbContext>(EnsureSeedIS4Data)
                .MigrateDbContext<AppIdentityDbContext>(EnsureSeedIdentityData)
                .MigrateDbContext<EventStoreContext>(null);

            return webHost;
        }

        private static void EnsureSeedIdentityData(AppIdentityDbContext context, IServiceProvider sp)
        {

        }

        private static void EnsureSeedIS4Data(IDS4DbContext context, IServiceProvider sp)
        {

        }
    }
}
