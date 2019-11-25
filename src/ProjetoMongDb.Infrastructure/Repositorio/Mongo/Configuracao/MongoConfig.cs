using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace ProjetoMongDb.Infrastructure.Repositorio.Mongo.Configuracao
{
    public class MongoConfig : IMongoConfig
    {
        public MongoConfig(IConfiguration configuration)
        {
            var mongoUrl = new MongoUrl(configuration.GetConnectionString("MongoDb"));
            var client = new MongoClient(mongoUrl);
            Context = client.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoDatabase Context { get; }
    }
}
