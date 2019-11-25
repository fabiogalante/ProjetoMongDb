using System;

namespace ProjetoMongDb.Domain.Ted
{
    public class TedEnviadaDto
    {
        public Guid CorrelationId { get; set; }

        public string Agencia { get; set; }

        public string SolicitadoEm { get; set; }

        public string NumeroCNPJ { get; set; }

        public string AgenciaDigito { get; set; }

        public string BancoId { get; set; }

        public string Conta { get; set; }

        public string ContaCorrenteID { get; set; }

        public string ContaDAC { get; set; }

        public string ContaDigito { get; set; }

        public string EfetivadoEm { get; set; }

        public string Favorecido { get; set; }

        public string FavorecidoIsento { get; set; }

        public string ID { get; set; }

        public string IdMotivoSuspensao { get; set; }

        public string ISPB { get; set; }

        public string LancamentoID { get; set; }

        public string NumeroCPF { get; set; }

        public string Observacao { get; set; }

        public string SegundoRetorno { get; set; }

        public string StatusID { get; set; }

        public string TipoContaId { get; set; }

        public string UsuarioID { get; set; }

        public string Valor { get; set; }
        
        public string FinalidadeCliente { get; set; }

        public int AgenciaDebito { get; set; }
        public long ContaDebito { get; set; }
        public string TipoContaDebito { get; set; }
        public string CpfCnpjDebito { get; set; }
        public string NomeDebito { get; set; }
        public string TipoPessoaDebito { get; set; }
    }
}
