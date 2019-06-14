using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Admin.Domain.Core.ViewModels;
using IdentityServer4.AdminUI.Apis;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IdentityServer4.AdminUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersApi _usersApi;
        public UsersController(IUsersApi usersApi)
        {
            _usersApi = usersApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List([FromQuery]PagingQueryViewModel model)
        {
            var response = await _usersApi.GetUsersAsync(model);
            return Json(response);
        }
    }
}