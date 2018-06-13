using MediatR;
using MyCQRS.Domain.Core.Bus;
using MyCQRS.Domain.Core.Notifications;
using MyCQRS.Domain.Photographers.Events;
using MyCQRS.Domain.Photographers.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyCQRS.Domain.Photographers.Commands
{
    public class PhotographerCommandHandler :
        IRequestHandler<AddPhotographerCommand>,
        IRequestHandler<UpdatePhotographerCommand>,
        IRequestHandler<RemovePhotographerCommand>
    {
        private readonly IPhotographerRepository _repository;
        private readonly IBus _bus;

        public PhotographerCommandHandler(IBus bus, IPhotographerRepository repository)
        {
            _repository = repository;
            _bus = bus;
        }

        public Task<Unit> Handle(AddPhotographerCommand request, CancellationToken cancellationToken)
        {
            var photographer = new Photographer(Guid.NewGuid(), request.Name, request.Email);

            _repository.Add(photographer);

            _bus.RaiseEvent(new PhotographerAddedEvent(photographer.Id, photographer.Name, photographer.Email));

            return Unit.Task;
        }

        public Task<Unit> Handle(UpdatePhotographerCommand request, CancellationToken cancellationToken)
        {
            var photographer = new Photographer(request.Id, request.Name, request.Email);

            var existingPhotographer = _repository.FindByEmail(photographer.Email);

            if (existingPhotographer != null && existingPhotographer.Id != photographer.Id && !existingPhotographer.Equals(photographer))
            {
                _bus.RaiseEvent(new DomainNotification(request.GetCommandName(), "The photographer e-mail has already been taken."));
                return Unit.Task;
            }

            _repository.Update(photographer);
            _bus.RaiseEvent(new PhotographerUpdatedEvent(photographer.Id, photographer.Name, photographer.Email));

            return Unit.Task;
        }

        public Task<Unit> Handle(RemovePhotographerCommand request, CancellationToken cancellationToken)
        {
            _repository.Remove(request.Id);
            _bus.RaiseEvent(new PhotographerRemovedEvent(request.Id));

            return Unit.Task;
        }
    }
}