﻿using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Admin.Application.AutoMapper;
using IdentityServer4.Admin.Data.Mysql.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
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
                    options.ApiName = "ids4_api";

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
                    Title = "Identity Server 4 User Management API ",
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
                        { "ids4_api.user", "User Management API - full access" },
                        { "ids4_api.ids4", "IDS4 Management API - full access" },
                    }
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
            });

            return services;
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
}
