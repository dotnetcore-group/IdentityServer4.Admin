using IdentityServer4.Admin.API.Extensions;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
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
    [ApiVersion("1.0")]
    [Authorize(Policy = PolicyNames.AuthenticatedUser)]
    public class UserController : ApiController
    {
        public UserController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) 
            : base(notifications, mediator)
        {
        }

        [HttpGet]
        public string Get()
        {
            return "user";
        }
    }
}
