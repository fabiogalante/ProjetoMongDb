namespace ProjetoMongDb.Domain.Repositorio.Mongo
{
    public interface IMongoRepositorio
    {
        T Obter<T>(string parametro, string valor);
        void Inserir<T>(T document);
    }
}