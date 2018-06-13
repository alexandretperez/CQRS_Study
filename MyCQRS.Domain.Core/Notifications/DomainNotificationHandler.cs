using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyCQRS.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IDisposable, INotificationHandler<DomainNotification>
    {
        private readonly List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);

            return Task.CompletedTask;
        }

        public virtual bool HasNotifications() => _notifications.Count > 0;

        public virtual IReadOnlyCollection<DomainNotification> GetNotifications() => _notifications.AsReadOnly();

        public void Dispose()
        {
            _notifications.Clear();
        }
    }
}