using MongoDB.Driver;

namespace ProjetoMongDb.Infrastructure.Repositorio.Mongo.Configuracao
{
    public interface IMongoConfig
    {
        IMongoDatabase Context { get; }
    }
}