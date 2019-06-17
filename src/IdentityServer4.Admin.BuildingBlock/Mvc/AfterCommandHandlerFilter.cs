using IdentityServer4.Admin.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IdentityServer4.Admin.BuildingBlock.Mvc
{
    public class AfterCommandHandlerFilter : IActionFilter
    {
        private readonly DomainNotificationHandler _notifications;
        public AfterCommandHandlerFilter(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications as DomainNotificationHandler;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (_notifications.HasNotifications())
            {
                var errors = _notifications.GetNotifications();
                foreach (var error in errors)
                {
                    context.ModelState.AddModelError(error.Key, error.Value);
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
