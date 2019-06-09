using AutoMapper;
using IdentityModel;
using IdentityServer4.Admin.Application.AutoMapper;
using IdentityServer4.Admin.Data.Mysql.Extensions;
using IdentityServer4.Admin.Identity;
using IdentityServer4.Admin.Identity.Entities;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
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
            var idsBuilder = services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddAspNetIdentity<ApplicationUser>()
                .AddProfileService<IdentityWithAdditionalClaimsProfileService>();

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

            if (configuration.GetSection("ExternalLogin:GitHub").Exists())
            {
                authBuilder.AddGitHub("GitHub", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.ClientId = configuration.GetValue<string>("ExternalLogin:GitHub:ClientId");
                    options.ClientSecret = configuration.GetValue<string>("ExternalLogin:GitHub:ClientSecret");
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

        public static IServiceCollection AddMvcLocalization(this IServiceCollection services)
        {
            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

            services.Configure<RequestLocalizationOptions>(
                            opts =>
                            {
                                var supportedCultures = new[]
                                {
                                    new CultureInfo("zh-cn"),
                                    new CultureInfo("en-us"),
                                };

                                opts.DefaultRequestCulture = new RequestCulture("zh-cn");
                                opts.SupportedCultures = supportedCultures;
                                opts.SupportedUICultures = supportedCultures;
                            });

            return services;
        }

        public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EntityToViewModelMappingProfile).Assembly);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EntityToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
            });

            return services;
        }
    }
}
