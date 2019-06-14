using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class StartupController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly IStartupService _startup;
        public StartupController(IHostingEnvironment env,
            IStartupService startup)
        {
            _env = env;
            _startup = startup;
        }

        [HttpGet, Route("/")]
        public IActionResult Index()
        {
            var initialized = _startup.IsInitialized();
            if (initialized)
            {
                if (!_env.IsDevelopment())
                {
                    return NotFound();
                }
                return LocalRedirect("/swagger/index.html");
            }
            return LocalRedirect("/startup");
        }

        [HttpGet, Route("/startup")]
        public IActionResult Startup()
        {
            var model = new StartupViewModel();

            return View(model);
        }

        [HttpPost, Route("/startup")]
        public async Task<IActionResult> Startup(StartupViewModel model)
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
