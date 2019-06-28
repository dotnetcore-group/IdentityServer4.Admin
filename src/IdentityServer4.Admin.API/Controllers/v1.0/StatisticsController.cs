using IdentityServer4.Admin.API.Extensions;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.BuildingBlock.Mvc;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.API.Controllers.v1._0
{
    [Authorize(Policy = PolicyNames.Admin)]
    [Route(ApiRouteTemplate)]
    public class StatisticsController : ApiController
    {
        private readonly IUserManagerService _user;
        private readonly IClientService _client;
        public StatisticsController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator,
            IUserManagerService user,
            IClientService client)
            : base(notifications, mediator)
        {
            _user = user;
            _client = client;
        }

        [HttpGet, Route("total-users")]
        public async Task<ActionResult<JsonResponse<int>>> GetTotalUsers()
        {
            var total = await _user.GetTotalUsersAsync();
            return JsonResponse(total);
        }

        [HttpGet, Route("total-clients")]
        public async Task<ActionResult<JsonResponse<int>>> GetTotalClients()
        {
            var total = await _client.GetTotalClientsAsync();
            return JsonResponse(total);
        }
    }
}
