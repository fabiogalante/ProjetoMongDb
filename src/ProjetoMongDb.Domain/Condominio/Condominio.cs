using System;
using MongoDB.Bson;

namespace ProjetoMongDb.Domain.Condominio
{
    public class Condominio
    {
        public ObjectId _id { get; set; }
        public DateTime DataCadastro { get; set; }
        public string NomeCondominio { get; set; }
        public int NumeroTorres { get; set; }
    }
}
