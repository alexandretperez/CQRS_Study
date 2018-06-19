using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MyCQRS.Domain.Photographers;

namespace MyCQRS.Infra.Data.Data
{
    public class MongoDatabase
    {
        private readonly IMongoDatabase _db;
        private readonly IMongoClient _client;

        public MongoDatabase(string mongoDbConnection)
        {
            _client = new MongoClient(mongoDbConnection);
            _db = _client.GetDatabase("admin");
        }

        public MongoDatabase(IConfiguration configuration) : this(configuration.GetConnectionString("MongoDbConnection"))
        {
        }

        public IMongoCollection<Photographer> Photographers => _db.GetCollection<Photographer>("Photographers");
    }
}