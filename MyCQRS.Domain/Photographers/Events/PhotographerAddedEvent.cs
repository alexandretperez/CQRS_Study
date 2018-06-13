using MyCQRS.Domain.Core.Events;
using System;

namespace MyCQRS.Domain.Photographers.Events
{
    public class PhotographerAddedEvent : Event
    {
        public PhotographerAddedEvent(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Email { get; }
    }
}