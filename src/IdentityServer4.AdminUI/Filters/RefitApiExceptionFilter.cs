using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Refit;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServer4.AdminUI.Filters
{
    public class RefitApiExceptionFilter : IExceptionFilter
    {
        private readonly IConfiguration _configuration;
        public RefitApiExceptionFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception as ApiException;
            if (exception != null)
            {
                if (exception.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    context.Result = new RedirectResult("/login?returnUrl=" + context.HttpContext.Request.Path);
                    return;
                }
            }
        }

        /// <summary>
        /// refresh access token
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task<bool> RefreshTokensAsync(HttpContext httpContext)
        {
            var endpoint = _configuration.GetValue("IdentityUrl", "");
            using (var httpClient = new HttpClient())
            {
                var discovery = await httpClient.GetDiscoveryDocumentAsync(endpoint);
                if (!discovery.IsError)
                {
                    var refreshToken = await httpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

                    var request = new RefreshTokenRequest
                    {
                        Address = $"{endpoint}/{refreshToken}",
                        GrantType = "refresh_token",
                        RefreshToken = refreshToken,
                        ClientId = "IDS4-AdminUI",
                        ClientSecret = "234E496F-1927-47A4-B64E-8AF93C5F2F10",
                        Parameters = {
                            { "scope","ids4_admin_api offline_access"}
                        }
                    };

                    var response = await httpClient.RequestRefreshTokenAsync(request);
                    if (response.IsError)
                    {
                        return false;
                    }

                    var identityToken = await httpContext.GetTokenAsync("identity_token");
                    var expiresAt = DateTime.UtcNow + TimeSpan.FromSeconds(response.ExpiresIn);
                    var tokens = new[]
                    {
                        new AuthenticationToken
                        {
                            Name = OpenIdConnectParameterNames.IdToken,
                            Value = identityToken
                        },
                        new AuthenticationToken
                        {
                            Name = OpenIdConnectParameterNames.AccessToken,
                            Value = response.AccessToken
                        },
                        new AuthenticationToken
                        {
                            Name = OpenIdConnectParameterNames.RefreshToken,
                            Value = response.RefreshToken
                        },
                        new AuthenticationToken
                        {
                            Name = "expires_at",
                            Value = expiresAt.ToString("o", CultureInfo.InvariantCulture)
                        }
                    };


                    var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    var authenticationInfo = await httpContext.AuthenticateAsync(scheme);
                    authenticationInfo.Properties.StoreTokens(tokens);
                    await httpContext.SignInAsync(scheme, authenticationInfo.Principal, authenticationInfo.Properties);

                    return true;
                }
            }

            return false;
        }
    }
}
