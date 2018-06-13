using MyCQRS.Domain.Core.Commands;
using System;

namespace MyCQRS.Domain.Photographers.Commands
{
    public class RemovePhotographerCommand : Command
    {
        public RemovePhotographerCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}