using MongoDB.Driver;
using MyCQRS.Domain.Photographers;
using MyCQRS.Domain.Photographers.Interfaces;
using MyCQRS.Infra.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCQRS.Infra.Data.Repositories
{
    public class PhotographerRepository : IPhotographerRepository
    {
        public PhotographerRepository(MongoDatabase db)
        {
            Db = db;
        }

        public MongoDatabase Db { get; }

        public void Add(Photographer entity)
        {
            Db.Photographers.InsertOne(entity);
        }

        public Photographer FindByEmail(string email)
        {
            return Db.Photographers.Find(p => p.Email == email).FirstOrDefault();
        }

        public Photographer FindById(Guid id)
        {
            return Db.Photographers.Find(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Photographer> GetAll()
        {
            return Db.Photographers.Find(FilterDefinition<Photographer>.Empty).ToList();
        }

        public void Remove(Guid id)
        {
            Db.Photographers.FindOneAndDelete(p => p.Id == id);
        }

        public void Update(Photographer entity)
        {
            Db.Photographers.FindOneAndReplace(p => p.Id == entity.Id, entity);
        }
    }
}