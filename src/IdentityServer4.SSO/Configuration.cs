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
            new IdentityResource("is4-rights", "IdentityServer4 Admin Panel Permissions", new [] { "is4-rights"})
        };

        public static IEnumerable<ApiResource> GetApiResources() => new List<ApiResource> {
             new ApiResource {
                Name = "jp_api",
                DisplayName = "JP API",
                Description = "OAuth2 Server Management Api",
                ApiSecrets = { new Secret("Q&tGrEQMypEk.XxPU:%bWDZMdpZeJiyMwpLv4F7d**w9x:7KuJ#fy,E8KPHpKz++".Sha256()) },

                UserClaims =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "is4-rights",
                    "username",
                    "roles"
                },

                Scopes = {
                    new Scope() { Name = "jp_api.user",
                        DisplayName = "User Management - Full access",
                        Description = "Full access to User Management",
                        Required = true
                    },
                    new Scope() { Name = "jp_api.is4",
                        DisplayName = "OAuth2 Server",
                        Description = "Manage mode to IS4",
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
                        "jp_api.user",
                        "jp_api.is4",
                    }
            }
        };

    }
}
