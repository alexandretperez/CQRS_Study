using MediatR;
using System;

namespace MyCQRS.Domain.Core.Events
{
    public abstract class Event : INotification
    {
        protected DateTime Timestamp { get; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}