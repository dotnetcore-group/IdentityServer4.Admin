using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.SSO.Controllers
{
    [Authorize]
    public class GrantsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
