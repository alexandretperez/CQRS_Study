using MyCQRS.Domain.Core.Events;
using System;

namespace MyCQRS.Domain.Photographers.Events
{
    public class PhotographerRemovedEvent : Event
    {
        public PhotographerRemovedEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}