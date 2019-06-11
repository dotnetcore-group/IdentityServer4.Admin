using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Application.ViewModels.ApiResource;
using IdentityServer4.Admin.BuildingBlock.Mvc;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.Admin.API.Controllers.v1._0
{
    [Route(ApiRouteTemplate)]
    [ApiVersion("1.0")]
    public class ApiResourceController : ApiController
    {
        private readonly IApiResourceService _apiService;
        public ApiResourceController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IApiResourceService apiService)
            : base(notifications, mediator)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<ActionResult<JsonResponse<IEnumerable<ApiResourceViewModel>>>> Get()
        {
            var resources = await _apiService.GetApiResourcesAsync();
            return JsonResponse(resources);
        }

        [HttpGet, Route("{name}")]
        public async Task<ActionResult<JsonResponse<ApiResource>>> Get(string name)
        {
            var resource = await _apiService.GetApiResourceAsync(name);
            return JsonResponse(resource);
        }

        [HttpPost]
        public async Task<ActionResult<JsonResponse<bool>>> Post([FromBody]ApiResource model)
        {
            if (ModelState.IsValid == false)
            {
                NotifyModelStateErrors();
                return JsonResponse(false);
            }
            await _apiService.AddAsync(model);
            return JsonResponse(true);
        }

        #region SECRET
        [HttpGet, Route("{name}/secrets")]
        public async Task<ActionResult<JsonResponse<IEnumerable<SecretViewModel>>>> Secrets(string name)
        {
            var secrets = await _apiService.GetSecretsAsync(name);
            return JsonResponse(secrets);
        }

        [HttpDelete, Route("secret")]
        public async Task<ActionResult<JsonResponse<bool>>> RemoveSecret([FromBody]RemoveApiSecretViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return JsonResponse(false);
            }
            await _apiService.RemoveSecrectAsync(model);
            return JsonResponse(true);
        }

        [HttpPost, Route("secret")]
        public async Task<ActionResult<JsonResponse<bool>>> AddSecret([FromBody]SetApiSecretViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return JsonResponse(false);
            }
            await _apiService.SetSecretAsync(model);
            return JsonResponse(true);
        }
        #endregion

        #region SCOPE
        [HttpGet, Route("{name}/scopes")]
        public async Task<ActionResult<JsonResponse<IEnumerable<ScopeViewModel>>>> Scopes(string name)
        {
            var scopes = await _apiService.GetScopesAsync(name);
            return JsonResponse(scopes);
        }

        [HttpDelete, Route("scope")]
        public async Task<ActionResult<JsonResponse<bool>>> RemoveScope([FromBody]RemoveApiScopeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return JsonResponse(false);
            }
            await _apiService.RemoveScopeAsync(model);
            return JsonResponse(true);
        }

        [HttpPost, Route("scope")]
        public async Task<ActionResult<JsonResponse<bool>>> AddScope([FromBody]SetApiScopeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return JsonResponse(false);
            }
            await _apiService.SetScopeAsync(model);
            return JsonResponse(true);
        }
        #endregion
    }
}
