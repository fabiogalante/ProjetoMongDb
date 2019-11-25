using MongoDB.Driver;
using ProjetoMongDb.Domain.Repositorio.Mongo;
using ProjetoMongDb.Infrastructure.Repositorio.Mongo.Configuracao;

namespace ProjetoMongDb.Infrastructure.Repositorio.Mongo
{
    public class MongoRepositorio : IMongoRepositorio
    {
        private readonly IMongoDatabase context;

        public MongoRepositorio(IMongoConfig mongoConfig)
        {
            context = mongoConfig.Context;
        }

        public T Obter<T>(string parametro, string valor)
        {
            var filter = $"{parametro}:'{valor}'";
            return context.GetCollection<T>(nameof(T)).Find(filter).FirstOrDefault();
        }

        public void Inserir<T>(T document)
        {
            context.GetCollection<T>(document.GetType().Name).InsertOne(document);
        }
    }
}
