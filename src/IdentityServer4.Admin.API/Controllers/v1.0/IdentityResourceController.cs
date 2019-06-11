using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.API.Controllers.v1._0
{
    [Route(ApiRouteTemplate)]
    [ApiVersion("1.0")]
    public class IdentityResourceController : ApiController
    {
        public IdentityResourceController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) 
            : base(notifications, mediator)
        {
        }

        [HttpGet]
        public void Get() { }
    }
}
