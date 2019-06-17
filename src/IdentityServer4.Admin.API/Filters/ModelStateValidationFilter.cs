using IdentityServer4.Admin.BuildingBlock.Mvc;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.API.Filters
{
    public class ModelStateValidationFilter : IActionFilter
    {
        protected readonly DomainNotificationHandler _notifications;
        protected readonly IMediatorHandler _mediator;
        public ModelStateValidationFilter(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    var message = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                    NotifyError(string.Empty, message);
                }

                var result = Response();
                context.Result = result;
            }
        }

        protected IActionResult Response()
        {
            var errors = _notifications.GetNotifications()?.Select(n => n.Value);
            return new BadRequestObjectResult(new JsonResponse<bool>(errors));
        }

        private void NotifyError(string code, string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }
    }
}
