using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer4.Admin.Data.Mysql.Extensions
{
    public static class IIdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder UseIdentityServerMySqlDatabase(this IIdentityServerBuilder builder, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SSOConnection");
            var migrationsAssembly = "IdentityServer4.Admin.Data";

            // this adds the config data from DB (clients, resources)
            builder.AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b =>
                    b.UseMySql(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            })
                // this adds the operational data from DB (codes, tokens, consents)
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b =>
                        b.UseMySql(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));

                    // this enables automatic token cleanup. this is optional.
                    //options.EnableTokenCleanup = true;
                    //options.TokenCleanupInterval = 15; // frequency in seconds to cleanup stale grants. 15 is useful during debugging
                });

            return builder;
        }
    }
}
