using System.Collections.Generic;
using ProjetoMongDb.Domain.Ted;

namespace Super.IntegracaoSpb.Domain.Ted
{
    public class TedRecebidaDto
    {
        public List<ErroRetornoMensagem> Erro { get; set; } = new List<ErroRetornoMensagem>();
        public bool AnaliseRisco { get; set; }
        public string CodigoSistemaLegado { get; set; }
        public string NumeroOperacaoSistemaLegado { get; set; }
        public int CodigoSituacaoMensagem { get; set; }
        public string NumCtrlStrPag { get; set; }
        public string DataMovimento { get; set; }
        public string DtHrBC { get; set; }
        public string AgDebtd { get; set; }
        public int TipocontaDebitada { get; set; }
        public string ContaDebitada { get; set; }
        public int TipoPessoaDebitada { get; set; }
        public string CnpjCpfClienteDebitado { get; set; }
        public string NomeClienteDebitado { get; set; }
        public string IspbIfCreditada { get; set; }
        public string IspbIfDebitada { get; set; }
        public string AgenciaCreditada { get; set; }
        public int TipocontaCreditada { get; set; }
        public string ContaCreditada { get; set; }
        public int TipoPessoaCreditada { get; set; }
        public string CnpjCpfClienteCreditado { get; set; }
        public string NomeClienteCreditado { get; set; }
        public decimal ValorLancamento { get; set; }
        public string FinlddCli { get; set; }
        public string CodDevTransf { get; set; }
        public string NumCtrlSTROr { get; set; }
        public string Hist { get; set; }
        public string Xml { get; set; } = "";
    }
}
