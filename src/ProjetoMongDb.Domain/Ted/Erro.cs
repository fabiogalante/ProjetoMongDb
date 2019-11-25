using System;

namespace ProjetoMongDb.Domain.Ted
{
    public class Erro
    {
        public DateTime DataErro { get; set; }
        public string Property { get; set; }
        public string Message { get; set; }
    }
}
