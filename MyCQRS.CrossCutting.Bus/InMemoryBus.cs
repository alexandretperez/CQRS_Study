using MediatR;
using MyCQRS.Domain.Core.Bus;
using MyCQRS.Domain.Core.Commands;
using MyCQRS.Domain.Core.Events;
using System.Threading.Tasks;

namespace MyCQRS.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IBus
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}