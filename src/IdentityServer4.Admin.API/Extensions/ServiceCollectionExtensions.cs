using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Admin.Data.Mysql.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer4.Admin.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureIdentityDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityContextMySql(configuration);

            return services;
        }

        public static IServiceCollection AddIdentityServerAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                })
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration.GetValue<string>("ApplicationSettings:AuthorityUrl");
                    options.RequireHttpsMetadata = false;
                    options.ApiSecret = "wtfDvtL297yZ6sguv1T6c4@=-rt~aN%a03?H}mdK8YJYkMo4KLR:Yybr6pRse,@+>Q^ZsyYtyH}N+=#s-pVWc9!A1,m%z#WbxHu:";
                    options.ApiName = "ids4_api";

                });

            return services;
        }
    }
}
