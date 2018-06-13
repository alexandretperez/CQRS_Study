using MyCQRS.Domain.Core.Commands;

namespace MyCQRS.Domain.Photographers.Commands
{
    public class AddPhotographerCommand : Command
    {
        public AddPhotographerCommand(string name, string email)
        {
            Email = email;
            Name = name;
        }

        public string Email { get; }
        public string Name { get; }
    }
}