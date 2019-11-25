using System.Collections.Generic;
using MongoDB.Bson;
using ProjetoMongDb.Domain.Ted;

namespace ProjetoMongDb.Domain.Repositorio.Mongo
{
    public interface ITedRepositorio
    {
        void Inserir(Ted.Ted ted);
        void InserirMensagem(ObjectId _id, ICollection<Mensagem> mensagens);
        void InserirErro(ObjectId _id, ICollection<Erro> erros);
        void AtualizarNumeroOperacao(ObjectId _id, string numeroOperacao);
        void AtualizarNumCtrlSTR(ObjectId _id, string numCtrlSTR);
        Ted.Ted ObterTerPorNumeroOperacao(string numeroOperacao);
        Ted.Ted ObterTedPorNumeroControleSTR(string numCtrlSTR);
        Ted.Ted ObterTedPorNumeroControlePAG(string numCtrlPAG);
        void AtualizarTedDevolucao(ObjectId _id, TedDevolucaoDto tedDevolucaoDto);
        void AtualizarTransacoesTransferenciasId(ObjectId _id, int transacoesTransferenciasId);
        void AtualizarMensagemInicial(ObjectId _id, string mensagemInicial);
        void AtualizarTedRecebimentoId(ObjectId _id, long tedRecebimentoId);
        void InserirMensagem(ObjectId id, Mensagem mensagem);
    }
}