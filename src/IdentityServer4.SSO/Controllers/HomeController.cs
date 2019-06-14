using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityServer4.SSO.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Admin.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace IdentityServer4.SSO.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStartupService _startup;
        private readonly IIdentityServerInteractionService _interaction;
        public HomeController(IIdentityServerInteractionService interaction,
            IStartupService startup)
        {
            _interaction = interaction;
            _startup = startup;
        }

        public IActionResult Index()
        {
            var initialized = _startup.IsInitialized();
            if (!initialized)
            {
                return LocalRedirect("/startup");
            }

            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;
            }

            return View("Error", vm);
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        /// <summary>
        /// Shows the error page
        /// </summary>
        [HttpGet]
        public IActionResult LoginError(string error)
        {
            var vm = new ErrorViewModel();

            if (error != null)
            {
                vm.Error = new ErrorMessage() { ErrorDescription = error, Error = "1000" };
            }

            return View("Error", vm);
        }
    }
}
