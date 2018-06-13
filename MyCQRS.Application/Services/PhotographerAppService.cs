using MyCQRS.Application.Interfaces;
using MyCQRS.Application.ViewModels;
using MyCQRS.Domain.Core.Bus;
using MyCQRS.Domain.Photographers.Commands;
using MyCQRS.Domain.Photographers.Interfaces;
using Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCQRS.Application.Services
{
    public class PhotographerAppService : ApplicationService, IPhotographerAppService
    {
        private readonly IMapper _mapper;
        private readonly IPhotographerRepository _repository;

        public PhotographerAppService(IMapper mapper, IBus bus, IPhotographerRepository repository) : base(mapper, bus)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task Add(PhotographerViewModel model)
        {
            return Bus.SendCommand(new AddPhotographerCommand(model.Name, model.Email));
        }

        public PhotographerViewModel FindById(Guid id)
        {
            return Map<PhotographerViewModel>(_repository.FindById(id));
        }

        public List<PhotographerViewModel> GetAll()
        {
            return MapList<PhotographerViewModel>(_repository.GetAll());
        }

        public void Remove(Guid id)
        {
            Bus.SendCommand(new RemovePhotographerCommand(id));
        }

        public void Update(PhotographerViewModel model)
        {
            Bus.SendCommand(new UpdatePhotographerCommand(Guid.Parse(model.Id), model.Name, model.Email));
        }
    }
}