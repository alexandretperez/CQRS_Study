using MyCQRS.Domain.Core.Commands;
using System;

namespace MyCQRS.Domain.Photographers.Commands
{
    public class UpdatePhotographerCommand : Command
    {
        public UpdatePhotographerCommand(Guid id, string name, string email)
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