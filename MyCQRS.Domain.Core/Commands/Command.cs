using MediatR;
using System;

namespace MyCQRS.Domain.Core.Commands
{
    public abstract class Command : IRequest
    {
        protected DateTime Timestamp { get; }

        public string GetCommandName() => GetType().Name;

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}