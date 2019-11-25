using System;
using System.Collections.Generic;
using Flunt.Notifications;
using MongoDB.Bson;
using ProjetoMongDb.Domain.Repositorio.Mongo;
using Super.IntegracaoSpb.Domain.Ted;

namespace ProjetoMongDb.Domain.Ted
{
    public class Ted
    {
        private ITedRepositorio _tedRepositorio;
        private string _mensagemInicial;

        public Ted(ITedRepositorio tedRepositorio)
        {
            _tedRepositorio = tedRepositorio;
            DataOperacao = DateTime.Now;
            Mensagens = new List<Mensagem>();
            Erros = new List<Erro>();
            TedEnviadaDto = new TedEnviadaDto();
            TedRecebidaDto = new TedRecebidaDto();
            TedDevolucaoDto = new TedDevolucaoDto();
        }

        public ObjectId _id { get; set; }
        public int TransacoesTransferenciasId { get; set; }
        public long TedRecebimentoId { get; set; }
        public DateTime DataOperacao { get; private set; }
        public string CorrelationIdInterno { get; set; }
        public string CorrelationIdExterno { get; set; }
        public string NumeroOperacao { get; set; }
        public string NumCtrlStrPag { get; set; }
        public string MensagemInicial { get => _mensagemInicial; set => _mensagemInicial = string.IsNullOrEmpty(_mensagemInicial) ? value : _mensagemInicial; }
        public TedEnviadaDto TedEnviadaDto { get; set; }
        public TedRecebidaDto TedRecebidaDto { get; set; }
        public TedDevolucaoDto TedDevolucaoDto { get; set; }

        public ICollection<Mensagem> Mensagens { get; set; }
        public ICollection<Erro> Erros { get; set; }

        public void SalvarErros()
        {
            _tedRepositorio.InserirErro(_id, Erros);
        }

        public void SalvarMensagens()
        {
            _tedRepositorio.InserirMensagem(_id, Mensagens);
        }

        public void AtualizarNumeroOperacao()
        {
            _tedRepositorio.AtualizarNumeroOperacao(_id, NumeroOperacao);
        }

        public void AdicionarMensagem(Mensagem mensagem)
        {
            _tedRepositorio.InserirMensagem(_id, mensagem);
        }

        public void AtualizarNumCtrlSTR()
        {
            _tedRepositorio.AtualizarNumCtrlSTR(_id, NumCtrlStrPag);
        }

        public void Adicionar(ICollection<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                Erros.Add(new Erro { DataErro = DateTime.Now, Property = notification.Property, Message = notification.Message });
            }
        }

        public void Adicionar(Notification notification)
        {
            Erros.Add(new Erro { DataErro = DateTime.Now, Property = notification.Property, Message = notification.Message });
        }

        public void SetITedRepositorio(ITedRepositorio tedRepositorio)
        {
            _tedRepositorio = tedRepositorio;
        }

        public void AtualizarTedDevolucao()
        {
            _tedRepositorio.AtualizarTedDevolucao(_id, TedDevolucaoDto);
        }

        public void AtualizarTransacoesTransferenciasId()
        {
            _tedRepositorio.AtualizarTransacoesTransferenciasId(_id, TransacoesTransferenciasId);
        }

        public void AtualizarMensagemInicial()
        {
            _tedRepositorio.AtualizarMensagemInicial(_id, MensagemInicial);
        }

        public void AtualizarTedRecebimentoId()
        {
            _tedRepositorio.AtualizarTedRecebimentoId(_id, TedRecebimentoId);
        }
    }
}
