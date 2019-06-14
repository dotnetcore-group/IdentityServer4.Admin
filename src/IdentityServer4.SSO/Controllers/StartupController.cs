using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.API.Controllers
{
    public class StartupController : Controller
    {
        private readonly IStartupService _startup;
        public StartupController(IStartupService startup)
        {
            _startup = startup;
        }


        [HttpGet, Route("/startup")]
        public IActionResult Index()
        {
            var model = new StartupViewModel();

            return View(model);
        }

        [HttpPost, Route("/startup")]
        public async Task<IActionResult> Index(StartupViewModel model)
        {
            var result = await _startup.Initialize(model);

            if (result.result)
            {
                return Redirect("/");
            }

            result.errors?.ForEach(error =>
            {
                ModelState.AddModelError(error.Code, error.Description);
            });

            return View(model);
        }
    }
}
