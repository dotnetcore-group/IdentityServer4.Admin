using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.SSO
{
    public class Configuration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource("username", new[]{"username" }),
            new IdentityResource("roles", "Roles", new[] { JwtClaimTypes.Role }),
            new IdentityResource("ids4_api-rights", "IdentityServer4 Admin Panel Permissions", new [] { "ids4_api-rights"})
        };

        public static IEnumerable<ApiResource> GetApiResources() => new List<ApiResource> {
             new ApiResource {
                Name = "ids4_api",
                DisplayName = "IDS4 API",
                Description = "OAuth2 Server Management Api",
                ApiSecrets = { new Secret("Q&tGrEQMypEk.XxPU:%bWDZMdpZeJiyMwpLv4F7d**w9x:7KuJ#fy,E8KPHpKz++".Sha256()) },

                UserClaims =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "ids4_api-rights",
                    "username",
                    "roles"
                },

                Scopes = {
                    new Scope() { Name = "ids4_api.user",
                        DisplayName = "User Management - Full access",
                        Description = "Full access to User Management",
                        Required = true
                    },
                    new Scope() { Name = "ids4_api.ids4",
                        DisplayName = "OAuth2 Server",
                        Description = "Manage mode to IDS4",
                        Required = true
                    }
                 }
             }
        };

        public static IEnumerable<Client> GetClients() => new List<Client>
        {
            new Client{
                ClientId = "Swagger",
                    ClientName = "Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = true,
                    RedirectUris =
                    {
                        "http://localhost:5004/swagger/oauth2-redirect.html"
                    },
                    AllowedScopes =
                    {
                        "ids4_api.user",
                        "ids4_api.ids4",
                    }
            }
        };

    }
}
