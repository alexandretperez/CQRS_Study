using MyCQRS.Domain.Core.Bus;
using Output;
using System.Collections.Generic;

namespace MyCQRS.Application.Services
{
    public abstract class ApplicationService
    {
        protected ApplicationService(IMapper mapper, IBus bus)
        {
            Mapper = mapper;
            Bus = bus;
        }

        public IMapper Mapper { get; }
        public IBus Bus { get; }

        public T Map<T>(object source) => Mapper.Map<T>(source);

        public List<T> MapList<T>(object source) => Map<List<T>>(source);
    }
}