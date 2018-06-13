using MediatR;
using MyCQRS.Domain.Core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace MyCQRS.Domain.Photographers.Events
{
    public class PhotographerEventHandler :
        INotificationHandler<PhotographerAddedEvent>,
        INotificationHandler<PhotographerUpdatedEvent>,
        INotificationHandler<PhotographerRemovedEvent>
    {
        private readonly IBus _bus;

        public PhotographerEventHandler(IBus bus)
        {
            this._bus = bus;
        }

        public Task Handle(PhotographerAddedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PhotographerUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PhotographerRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}