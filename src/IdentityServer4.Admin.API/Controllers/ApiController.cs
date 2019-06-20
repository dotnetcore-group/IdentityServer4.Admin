using IdentityServer4.Admin.BuildingBlock.Mvc;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.API.Controllers
{
    //[ApiController]
    public abstract class ApiController : ControllerBase
    {
        public const string ApiRouteTemplate = "api/v{version:apiVersion}/[controller]";

        protected readonly DomainNotificationHandler _notifications;
        protected readonly IMediatorHandler _mediator;
        public ApiController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();
        protected bool IsValidOperation => !_notifications.HasNotifications();

        protected ActionResult<JsonResponse<T>> JsonResponse<T>(T data)
        {
            if (IsValidOperation)
            {
                return Ok(new JsonResponse<T>(true, data));
            }

            var errors = Notifications?.Select(n => n.Value);
            return Ok(new JsonResponse<T>(errors));
        }

        protected void NotifyModelStateErrors()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                var message = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(string.Empty, message);
            }
        }

        protected void NotifyError(string code, string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }

        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                NotifyError(result.ToString(), error.Description);
            }
        }
    }
}
