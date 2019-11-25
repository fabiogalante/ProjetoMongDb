using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProjetoMongDb.Domain.Repositorio.Mongo;
using ProjetoMongDb.Infrastructure.Repositorio;
using ProjetoMongDb.Infrastructure.Repositorio.Mongo;
using ProjetoMongDb.Infrastructure.Repositorio.Mongo.Configuracao;

namespace ProjetoMongDb.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class MongoDbServiceCollectionExtensions
    {
        public static void AddMongo(this IServiceCollection services)
        {
            services.AddScoped<IMongoConfig, MongoConfig>();
            services.AddScoped<IMongoRepositorio, MongoRepositorio>();
            services.AddScoped<ITedRepositorio, TedRepositorio>();
            services.AddScoped<ICondominioRepositorio, CondominioRepositorio>();
        }
    }
}
