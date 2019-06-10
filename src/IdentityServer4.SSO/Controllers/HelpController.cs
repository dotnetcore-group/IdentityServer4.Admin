using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.SSO.Controllers
{
    public class HelpController : Controller
    {
        [HttpGet, Route("privacy")]
        public IActionResult PrivacyStatement()
        {
            return View();
        }

        [HttpGet, Route("terms")]
        public IActionResult TermsOfService()
        {
            return View();
        }
    }
}