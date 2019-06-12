using IdentityServer4.Admin.API.Extensions;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels.User;
using IdentityServer4.Admin.BuildingBlock.Mvc;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Admin.Domain.Core.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.API.Controllers.v1._0
{
    [Route(ApiRouteTemplate)]
    [ApiVersion("1.0")]
    [Authorize(Policy = PolicyNames.AuthenticatedUser)]
    public class UsersController : ApiController
    {
        private readonly IUserManagerService _userManagerService;
        public UsersController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IUserManagerService userManagerService)
            : base(notifications, mediator)
        {
            _userManagerService = userManagerService;
        }

        [HttpGet]
        public async Task<ActionResult<JsonResponse<PagingDataViewModel<PagingUserViewModel>>>> Get([FromQuery]PagingQueryViewModel vm)
        {
            var users = await _userManagerService.GetUsersAsync(vm);
            return JsonResponse(users);
        }
    }
}
