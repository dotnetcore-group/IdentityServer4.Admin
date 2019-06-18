using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServer4.SSO
{
    public class Configuration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource("username", new[]{ "username" }),
            new IdentityResource("roles", "Roles", new[] { JwtClaimTypes.Role}),
            new IdentityResource("ids4_api-rights", "IdentityServer4 Admin Panel Permissions", new [] { "ids4_api-rights"})
        };

        public static IEnumerable<ApiResource> GetApiResources() => new List<ApiResource> {
             new ApiResource {
                Name = "ids4_admin_api",
                DisplayName = "IDS4 Admin API",
                Description = "IdentityServer4 Admin API",
                ApiSecrets = { new Secret("Q&tGrEQMypEk.XxPU:%bWDZMdpZeJiyMwpLv4F7d**w9x:7KuJ#fy,E8KPHpKz++".Sha256()) { Type= "Sha256" } },

                Scopes = {
                    new Scope() { Name = "ids4_admin_api",
                        DisplayName = "IDS4 Admin API",
                        Description = "IdentityServer4 Admin API",
                        Required = true,
                        UserClaims = {
                            StandardScopes.OpenId,
                            StandardScopes.Profile,
                            StandardScopes.Email,
                            "ids4_api-rights",
                            "username",
                            "roles"
                        }
                    }
                 }
             }
        };

        public static IEnumerable<Client> GetClients() => new List<Client>
        {
            //new Client {
            //    ClientId="IDS4-AdminUI",
            //    ClientName="IdentityServer4 AdminUI",
            //    ClientUri="http://localhost:5000",
            //    LogoUri ="/images/ids4-admin.png",
            //    AllowedGrantTypes = GrantTypes.Hybrid,
            //    AllowAccessTokensViaBrowser = true,

            //    ClientSecrets = {
            //        new Secret("234E496F-1927-47A4-B64E-8AF93C5F2F10".Sha256())
            //    },

            //    RedirectUris = {
            //        "http://localhost:5000/signin-oidc",
            //        "https://localhost:5001/signin-oidc",
            //    },
            //    PostLogoutRedirectUris = {
            //        "http://localhost:5000/signout-callback-oidc",
            //        "https://localhost:5001/signout-callback-oidc",
            //    },
            //    AllowedCorsOrigins={
            //        "http://localhost:5000",
            //        "https://localhost:5001",
            //    },
            //    AccessTokenLifetime = 3600,
            //    AuthorizationCodeLifetime = 3600,
            //    AllowedScopes={
            //        StandardScopes.OpenId,
            //        StandardScopes.Profile,
            //        StandardScopes.Email,
            //        "ids4_admin_api",
            //    },
            //    AllowOfflineAccess = true,
            //    AlwaysIncludeUserClaimsInIdToken = true
            //},
            new Client {
                ClientId="ids4-admin-ui",
                ClientName="IdentityServer4 AdminUI",
                ClientUri="http://localhost:8000",
                LogoUri ="/images/ids4-admin.png",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,

                ClientSecrets = {
                    new Secret("266D5022-5BCA-45FF-BC77-EE013CA2A129".Sha256())
                },

                RedirectUris = {
                    "http://localhost:8000/signin-callback-oidc",
                },
                PostLogoutRedirectUris = {
                    "http://localhost:8000/signout-callback-oidc",
                },
                AllowedCorsOrigins={
                    "http://localhost:8000"
                },
                AccessTokenLifetime = 3600,
                AuthorizationCodeLifetime = 3600,
                AllowedScopes={
                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    "ids4_admin_api",
                },
                AllowOfflineAccess = true,
                AlwaysIncludeUserClaimsInIdToken = true
            },

            new Client{
                ClientId = "Swagger",
                ClientName = "Swagger UI",
                LogoUri="https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1559935898007&di=46e26c321df5ab863d2a86cfb27e57b8&imgtype=0&src=http%3A%2F%2F5b0988e595225.cdn.sohucs.com%2Fimages%2F20190526%2Fa1c8213bc0dd4cd09c6a43d069d106a9.gif",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,
                RequireConsent = true,
                RedirectUris =
                {
                    "http://localhost:5004/swagger/oauth2-redirect.html",
                    "https://localhost:5003/swagger/oauth2-redirect.html",
                },
                AllowedScopes =
                {
                    "ids4_admin_api"
                }
            }
        };

    }
}
