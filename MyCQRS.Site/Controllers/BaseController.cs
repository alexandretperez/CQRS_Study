using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCQRS.Application.Interfaces;
using MyCQRS.Application.ViewModels;
using MyCQRS.Domain.Core.Notifications;
using System;
using System.Threading.Tasks;

namespace MyCQRS.Controllers
{
    public class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;

        public BaseController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public bool IsOperationValid() => !_notifications.HasNotifications();
    }
}