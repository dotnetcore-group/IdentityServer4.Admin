using IdentityServer4.Admin.Data.Mysql.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer4.Admin.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureIdentityDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityContextMySql(configuration);
        }
    }
}
