using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using ProjetoMongDb.Domain.Repositorio.Mongo;
using ProjetoMongDb.Domain.Ted;
using ProjetoMongDb.Infrastructure.Repositorio.Mongo.Configuracao;

namespace ProjetoMongDb.Infrastructure.Repositorio.Mongo
{
    public class TedRepositorio : ITedRepositorio
    {
        private readonly IMongoDatabase context;

        public TedRepositorio(IMongoConfig mongoConfig)
        {
            context = mongoConfig.Context;
        }

        public void Inserir(Ted ted)
        {
            context.GetCollection<Ted>(nameof(Ted)).InsertOne(ted);
        }

        public void InserirMensagem(ObjectId _id, ICollection<Mensagem> mensagens)
        {
            var mensagemDefinition = Builders<Ted>.Update.PushEach(o => o.Mensagens, mensagens);
            context.GetCollection<Ted>(nameof(Ted)).UpdateOne(t => t._id == _id, mensagemDefinition);
        }

        public void InserirErro(ObjectId _id, ICollection<Erro> erros)
        {
            var mensagemDefinition = Builders<Ted>.Update.PushEach(o => o.Erros, erros);
            context.GetCollection<Ted>(nameof(Ted)).UpdateOne(t => t._id == _id, mensagemDefinition);
        }

        public void AtualizarNumeroOperacao(ObjectId _id, string numeroOperacao)
        {
            var definition = Builders<Ted>.Update.Set(t => t.NumeroOperacao, numeroOperacao);
            context.GetCollection<Ted>(nameof(Ted)).UpdateOne(t => t._id == _id, definition);
        }

        public Ted ObterTerPorNumeroOperacao(string numeroOperacao)
        {
            var filter = "{ NumeroOperacao: '" + numeroOperacao + "'}";
            var ted = context.GetCollection<Ted>("Ted").Find(filter).FirstOrDefault();

            if (ted != null)
            {
                //TODO: VERIFICAR. Estava limpandando as mensagens quando não era nulo. Não sei o motivo que foi feito. Preciso das mensagens pois
                // com elas consigo pegar a primeira mensagem, na primeira posição e saber qual foi o codigo da mensagem inicial                
                //ted.Mensagens.Clear();
                ted.Erros.Clear();
            }

            return ted;
        }

        public Ted ObterTedPorNumeroControleSTR(string numCtrlSTR)
        {
            var filter = "{ NumCtrlStrPag: '" + numCtrlSTR + "'}";
            var ted = context.GetCollection<Ted>("Ted").Find(filter).FirstOrDefault();

            if (ted != null)
            {
                ted.Mensagens.Clear();
                ted.Erros.Clear();
            }

            return ted;
        }

        public Ted ObterTedPorNumeroControlePAG(string numCtrlPAG)
        {
            var filter = "{ NumCtrlStrPag: '" + numCtrlPAG + "'}";
            var ted = context.GetCollection<Ted>("Ted").Find(filter).FirstOrDefault();

            ted.Mensagens.Clear();
            ted.Erros.Clear();

            return ted;
        }

        public void AtualizarNumCtrlSTR(ObjectId _id, string numCtrlSTR)
        {
            var definition = Builders<Ted>.Update.Set(t => t.NumCtrlStrPag, numCtrlSTR);
            context.GetCollection<Ted>(nameof(Ted)).UpdateOne(t => t._id == _id, definition);
        }

        public void AtualizarTedDevolucao(ObjectId _id, TedDevolucaoDto tedDevolucaoDto)
        {
            var definition = Builders<Ted>.Update.Set(t => t.TedDevolucaoDto, tedDevolucaoDto);
            context.GetCollection<Ted>(nameof(Ted)).UpdateOne(t => t._id == _id, definition);
        }

        public void AtualizarTransacoesTransferenciasId(ObjectId _id, int transacoesTransferenciasId)
        {
            var definition = Builders<Ted>.Update.Set(t => t.TransacoesTransferenciasId, transacoesTransferenciasId);
            context.GetCollection<Ted>(nameof(Ted)).UpdateOne(t => t._id == _id, definition);
        }

        public void AtualizarMensagemInicial(ObjectId _id, string mensagemInicial)
        {
            var definition = Builders<Ted>.Update.Set(t => t.MensagemInicial, mensagemInicial);
            context.GetCollection<Ted>(nameof(Ted)).UpdateOne(t => t._id == _id, definition);
        }

        public void AtualizarTedRecebimentoId(ObjectId _id, long tedRecebimentoId)
        {
            var definition = Builders<Ted>.Update.Set(t => t.TedRecebimentoId, tedRecebimentoId);
            context.GetCollection<Ted>(nameof(Ted)).UpdateOne(t => t._id == _id, definition);
        }

        public void InserirMensagem(ObjectId id, Mensagem mensagem)
        {
            context.GetCollection<Ted>(nameof(Ted)).UpdateOne(t => t._id == id, Builders<Ted>.Update.Push(t => t.Mensagens, mensagem));
        }
    }
}
