using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AdminUI.Apis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.AdminUI.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class ClientsController : Controller
    {
        private readonly IClientsApi _clientsApi;
        public ClientsController(IClientsApi clientsApi)
        {
            _clientsApi = clientsApi;
        }

        [HttpGet, Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("list")]
        public async Task<IActionResult> GetClients()
        {
            var response = await _clientsApi.GetClientsAsync();
            return Json(response);
        }
    }
}