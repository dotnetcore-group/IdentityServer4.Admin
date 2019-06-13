using IdentityServer4.Admin.API.Extensions;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels.Role;
using IdentityServer4.Admin.BuildingBlock.Mvc;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.API.Controllers.v1._0
{
    [Route(ApiRouteTemplate)]
    [ApiVersion("1.0")]
    [Authorize(Policy = PolicyNames.Admin)]
    public class RolesController : ApiController
    {
        private readonly IRoleService _roleService;
        public RolesController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IRoleService roleService)
            : base(notifications, mediator)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<JsonResponse<IEnumerable<RoleViewModel>>>> Get()
        {
            var roles = await _roleService.GetAllRolesAsync();

            return JsonResponse(roles);
        }
    }
}
