using IdentityServer4.Admin.API.Extensions;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels.IdentityResource;
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

        [HttpGet, Route("{name}")]
        public async Task<ActionResult<JsonResponse<IdentityResource>>> Get(string name)
        {
            var resource = await _identityResourceService.GetIdentityResourceAsync(name);
            return JsonResponse(resource);
        }

        [HttpPost]
        public async Task<ActionResult<JsonResponse<bool>>> Create([FromBody]CreateIdentityResourceViewModel model)
        {
            await _identityResourceService.CreateAsync(model);
            return JsonResponse(true);
        }

        [HttpDelete, Route("{name}")]
        public async Task<ActionResult<JsonResponse<bool>>> Remove(string name)
        {
            await _identityResourceService.RemoveAsync(name);
            return JsonResponse(true);
        }

        [HttpPut]
        public async Task<ActionResult<JsonResponse<bool>>> Update([FromBody]UpdateIdentityResourceViewModel model)
        {
            await _identityResourceService.UpdateAsync(model);
            return JsonResponse(true);
        }
    }
}
