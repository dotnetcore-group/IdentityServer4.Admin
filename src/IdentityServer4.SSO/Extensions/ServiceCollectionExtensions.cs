﻿using IdentityModel;
using IdentityServer4.Admin.Data.Mysql.Extensions;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer4.SSO.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureIdentityDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityMySql(configuration);
        }

        public static IServiceCollection ConfigureIdentityServerDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("SSOConnection");
            var idsBuilder = services.AddIdentityServer();

            idsBuilder.UseIdentityServerMySqlDatabase(configuration);

            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var authBuilder = services.AddAuthentication();

            if (configuration.GetSection("ExternalLogin:Google").Exists())
            {
                authBuilder.AddGoogle("Google", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.ClientId = configuration.GetValue<string>("ExternalLogin:Google:ClientId");
                    options.ClientSecret = configuration.GetValue<string>("ExternalLogin:Google:ClientSecret");
                    options.Events = new OAuthEvents
                    {
                        OnCreatingTicket = context =>
                        {
                            if (context.User.ContainsKey("image"))
                                context.Identity.AddClaim(new Claim(JwtClaimTypes.Picture, context.User.GetValue("image").SelectToken("url").ToString()));
                            return Task.CompletedTask;
                        }
                    };
                });
            }

            if (configuration.GetSection("ExternalLogin:Facebook").Exists())
            {
                authBuilder.AddFacebook("Facebook", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.ClientId = configuration.GetValue<string>("ExternalLogin:Facebook:ClientId");
                    options.ClientSecret = configuration.GetValue<string>("ExternalLogin:Facebook:ClientSecret");
                    options.Fields.Add("picture");
                    options.Events = new OAuthEvents
                    {
                        OnCreatingTicket = context =>
                        {
                            if (context.User.ContainsKey("picture"))
                                context.Identity.AddClaim(new Claim(JwtClaimTypes.Picture, context.User.GetValue("picture").SelectToken("data").SelectToken("url").ToString()));
                            return Task.CompletedTask;
                        }
                    };
                });
            }

            return services;
        }
    }
}
