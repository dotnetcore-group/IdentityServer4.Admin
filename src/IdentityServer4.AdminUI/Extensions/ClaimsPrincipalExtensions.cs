using IdentityModel;
using IdentityServer4.AdminUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace IdentityServer4.AdminUI.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static UserInfo GetUserInfo(this ClaimsPrincipal principal)
        {
            var claims = principal.Claims?.ToList();
            if (claims?.Count > 0)
            {
                return new UserInfo
                {
                    Email = claims.GetClaimValue(JwtClaimTypes.Email),
                    UserName = claims.GetClaimValue(JwtClaimTypes.Name),
                    Gravatar = claims.GetClaimValue("gravatar"),
                    Nickname = claims.GetClaimValue("nickname")
                };
            }

            return null;
        }

        private static string GetClaimValue(this List<Claim> claims, string type, string defValue = "")
            => claims.FirstOrDefault(c => c.Type == type)?.Value ?? defValue;
    }
}
