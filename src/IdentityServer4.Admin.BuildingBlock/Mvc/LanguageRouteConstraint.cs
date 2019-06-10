using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentityServer4.Admin.BuildingBlock.Mvc
{
    public class LanguageRouteConstraint : IRouteConstraint
    {
        private readonly string[] _langs = { "zh-cn", "en-us" };

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey("lang"))
            {
                return false;
            }
            var lang = values["lang"].ToString();

            return _langs.Any(l => l == lang.ToLower());
        }
    }
}
