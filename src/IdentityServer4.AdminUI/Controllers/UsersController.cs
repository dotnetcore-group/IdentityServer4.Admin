using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            var users = await _usersApi.GetUsersAsync(new Admin.Domain.Core.ViewModels.PagingQueryViewModel());
            return Content(JsonConvert.SerializeObject(users));
        }
    }
}