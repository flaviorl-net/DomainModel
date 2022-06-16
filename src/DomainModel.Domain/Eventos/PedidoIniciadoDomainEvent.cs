using DomainModel.Domain.Entities;
using MediatR;
using System;

namespace DomainModel.Domain.Eventos
{
    public class PedidoIniciadoDomainEvent : INotification
    {
        public int TipoCartao { get; }
        public string NumeroCartao { get; }
        public string NumeroSegurancaCartao { get; }
        public string NomeImpressoCartao { get; }
        public DateTime DataExpiracaoCartao { get; }
        public Pedido Pedido { get; }

        public PedidoIniciadoDomainEvent(Pedido pedido, int tipoCartao, string numeroCartao,
                                       string numeroSegurancaCartao, string nomeImpressoCartao,
                                       DateTime dataExpiracaoCartao)
        {
            Pedido = pedido;
            TipoCartao = tipoCartao;
            NumeroCartao = numeroCartao;
            NumeroSegurancaCartao = numeroSegurancaCartao;
            NomeImpressoCartao = nomeImpressoCartao;
            DataExpiracaoCartao = dataExpiracaoCartao;
        }
    }
}
