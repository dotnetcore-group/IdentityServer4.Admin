using IdentityServer4.Admin.API.Extensions;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels.IdentityResource;
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
    public class IdentityResourcesController : ApiController
    {
        private readonly IIdentityResourceService _identityResourceService;
        public IdentityResourcesController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IIdentityResourceService identityResourceService)
            : base(notifications, mediator)
        {
            _identityResourceService = identityResourceService;
        }

        [HttpGet]
        public async Task<ActionResult<JsonResponse<IEnumerable<IdentityResourceViewModel>>>> Get()
        {
            var resources = await _identityResourceService.GetIdentityResourcesAsync();
            return JsonResponse(resources);
        }
    }
}
