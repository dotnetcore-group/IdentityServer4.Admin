using IdentityServer4.Admin.API.Extensions;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.BuildingBlock.Mvc;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.API.Controllers.v1_0
{

    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(Policy = PolicyNames.Admin)]
    [ApiVersion("1.0")]
    public class ClientsController : ApiController
    {
        private readonly IClientService _clientService;
        public ClientsController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IClientService clientService) : base(notifications, mediator)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<JsonResponse<IList<Client>>>> Get()
        {
            var clients = await _clientService.GetClientsAsync();

            return JsonResponse(clients);
        }

        [HttpGet("{clientId}")]
        public async Task<ActionResult<JsonResponse<Client>>> Get(string clientId)
        {
            var client = await _clientService.GetClientDetails(clientId);

            return JsonResponse(client);
        }
    }
}
