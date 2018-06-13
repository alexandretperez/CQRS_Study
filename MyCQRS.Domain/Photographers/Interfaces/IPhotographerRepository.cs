using System;
using System.Collections.Generic;

namespace MyCQRS.Domain.Photographers.Interfaces
{
    public interface IPhotographerRepository
    {
        void Add(Photographer entity);

        void Update(Photographer entity);

        void Remove(Guid id);

        ICollection<Photographer> GetAll();

        Photographer FindByEmail(string email);

        Photographer FindById(Guid id);
    }
}