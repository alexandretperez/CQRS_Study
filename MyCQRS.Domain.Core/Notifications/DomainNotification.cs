using MyCQRS.Domain.Core.Events;
using System;

namespace MyCQRS.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
            NotificationId = Guid.NewGuid();
            Version = 1;
        }

        public string Key { get; }
        public string Value { get; }
        public Guid NotificationId { get; }
        public int Version { get; }
    }
}