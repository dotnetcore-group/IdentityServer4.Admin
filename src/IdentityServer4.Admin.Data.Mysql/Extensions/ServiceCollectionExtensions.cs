using IdentityServer4.Admin.Data.Database;
using IdentityServer4.Admin.Identity;
using IdentityServer4.Admin.Identity.Authorization;
using IdentityServer4.Admin.Identity.Entities;
using IdentityServer4.Admin.Infrastructures.Data.Database;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IdentityServer4.Admin.Data.Mysql.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityContextMySql(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SSOConnection");
            var migrationsAssembly = typeof(ServiceCollectionExtensions).GetTypeInfo().Assembly.GetName().Name;

            var operationalStoreOptions = new OperationalStoreOptions();
            services.AddSingleton(operationalStoreOptions);

            var storeOptions = new ConfigurationStoreOptions();
            services.AddSingleton(storeOptions);

            services.AddEntityFrameworkMySql()
                .AddDbContext<AppIdentityDbContext>(options =>
                    options.UseMySql(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly))
                );
            services.AddDbContext<IDS4DbContext>(options =>
                options.UseMySql(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly))
            );
            services.AddDbContext<EventStoreContext>(options =>
                options.UseMySql(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly))
            );

            return services;
        }

        public static IServiceCollection AddIdentityMySql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityContextMySql(configuration);

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                //.AddClaimsPrincipalFactory<ClaimsPrincipalFactory>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
