using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace IdentityServer4.Admin.Identity.Entities
{
    public class SystemUser
    {
        private readonly IHttpContextAccessor _accessor;

        public SystemUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Username => _accessor.HttpContext.User.FindFirst("username")?.Value;

        public string UserId => _accessor.HttpContext.User.FindFirst("sub")?.Value;
        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}
