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
            var migrationsAssembly = typeof(IS4DbContext).GetTypeInfo().Assembly.GetName().Name;

            var operationalStoreOptions = new OperationalStoreOptions();
            services.AddSingleton(operationalStoreOptions);

            var storeOptions = new ConfigurationStoreOptions();
            services.AddSingleton(storeOptions);

            services.AddEntityFrameworkMySql()
                .AddDbContext<ApplicationIdentityDbContext>(options =>
                    options.UseMySql(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly))
                );
            services.AddDbContext<IS4DbContext>(options =>
                options.UseMySql(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly))
            );

            return services;
        }

        public static IServiceCollection AddIdentityMySql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityContextMySql(configuration);

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
