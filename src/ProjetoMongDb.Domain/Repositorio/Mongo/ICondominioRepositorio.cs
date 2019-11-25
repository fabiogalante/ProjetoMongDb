using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMongDb.Domain.Repositorio.Mongo
{
    public interface ICondominioRepositorio
    {
        void Inserir(Condominio.Condominio condominio);
    }
}
