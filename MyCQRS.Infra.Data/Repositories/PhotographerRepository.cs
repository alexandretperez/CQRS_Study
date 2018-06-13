using MyCQRS.Domain.Photographers;
using MyCQRS.Domain.Photographers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCQRS.Infra.Data.Repositories
{
    public class PhotographerRepository : IPhotographerRepository
    {
        public void Add(Photographer entity)
        {
            FakeDatabase.Photographers.Add(entity);
        }

        public Photographer FindByEmail(string email)
        {
            return FakeDatabase.Photographers.FirstOrDefault(p => p.Email == email);
        }

        public Photographer FindById(Guid id)
        {
            return FakeDatabase.Photographers.FirstOrDefault(p => p.Id == id);
        }

        public ICollection<Photographer> GetAll()
        {
            return FakeDatabase.Photographers;
        }

        public void Remove(Guid id)
        {
            var entity = FakeDatabase.Photographers.FirstOrDefault(p => p.Id == id);
            if (entity != null)
                FakeDatabase.Photographers.Remove(entity);
        }

        public void Update(Photographer entity)
        {
            var index = FakeDatabase.Photographers.FindIndex(p => p.Id == entity.Id);
            if (index > -1)
                FakeDatabase.Photographers[index] = entity;
        }
    }
}