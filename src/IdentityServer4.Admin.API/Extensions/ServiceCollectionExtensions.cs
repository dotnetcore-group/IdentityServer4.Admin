using AutoMapper;
using IdentityModel;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Admin.Application.AutoMapper;
using IdentityServer4.Admin.Data.Mysql.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

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
            IdentityModelEventSource.ShowPII = true;

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                })
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration.GetValue<string>("AuthorityUrl");
                    options.RequireHttpsMetadata = false;
                    options.ApiSecret = "Q&tGrEQMypEk.XxPU:%bWDZMdpZeJiyMwpLv4F7d**w9x:7KuJ#fy,E8KPHpKz++";
                    options.ApiName = "ids4_admin_api";
                    options.RoleClaimType = JwtClaimTypes.Role;
                });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "IdentityServer4 Admin API",
                    Description = "Swagger surface",
                    Contact = new Contact { Name = "Ande Zeng", Email = "zengande@outlook.com", Url = "zengande.github.io" },
                    License = new License { Name = "MIT", Url = "" },

                });

                options.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "implicit",
                    AuthorizationUrl = $"{configuration.GetValue<string>("AuthorityUrl")}/connect/authorize",
                    TokenUrl = $"{configuration.GetValue<string>("AuthorityUrl")}/connect/token",
                    Scopes = new Dictionary<string, string> {
                        { "ids4_admin_api", "IDS4 Admin API - full access" }
                    },
                });
                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });

            return services;
        }

        public static IServiceCollection AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EntityToViewModelMappingProfile).Assembly);

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EntityToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
                cfg.AddProfile<EventToEntityMappingProfile>();
            });

            return services;
        }

        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyNames.Admin,
                    policy => policy.RequireAssertion(c =>
                        c.User.IsInRole("Administrator")));

                options.AddPolicy(PolicyNames.AuthenticatedUser, policy =>
                    policy.RequireAuthenticatedUser());
            });

            return services;
        }

        public static void ConfigureLocalization(this IServiceCollection services)
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
        }
    }

    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            // Check for authorize attribute
            var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AuthorizeAttribute>().Any();

            if (hasAuthorize)
            {
                operation.Responses.Add("401", new Response { Description = "Unauthorized" });
                operation.Responses.Add("403", new Response { Description = "Forbidden" });

                operation.Security = new List<IDictionary<string, IEnumerable<string>>> {
                    new Dictionary<string, IEnumerable<string>> {{"oauth2", new[] { "UserManagementApi.owner-content" } }}
                };
            }
        }
    }

    public class PolicyNames
    {
        public const string Admin = "Admin";
        public const string AuthenticatedUser = "User";
    }
}
