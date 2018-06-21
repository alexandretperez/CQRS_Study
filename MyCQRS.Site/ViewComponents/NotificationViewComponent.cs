using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCQRS.Domain.Core.Notifications;
using System.Threading.Tasks;

namespace MyCQRS.Site.ViewComponents
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _notifications;

        public NotificationViewComponent(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = await Task.FromResult(_notifications.GetNotifications());

            foreach (var n in notifications)
                ViewData.ModelState.AddModelError(string.Empty, n.Value);

            return View();
        }
    }
}