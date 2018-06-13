using MyCQRS.Domain.Core.Commands;
using MyCQRS.Domain.Core.Events;
using System.Threading.Tasks;

namespace MyCQRS.Domain.Core.Bus
{
    public interface IBus
    {
        Task SendCommand<T>(T command) where T : Command;

        Task RaiseEvent<T>(T @event) where T : Event;
    }
}