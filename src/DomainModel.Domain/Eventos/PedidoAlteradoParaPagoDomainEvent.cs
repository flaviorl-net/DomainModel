using DomainModel.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Domain.Eventos
{
    public class PedidoAlteradoParaPagoDomainEvent : INotification
    {
        public int PedidoId { get; }
        public IEnumerable<PedidoItem> PedidoItem { get; }

        public PedidoAlteradoParaPagoDomainEvent(int pedidoId,
            IEnumerable<PedidoItem> pedidoItem)
        {
            PedidoId = pedidoId;
            PedidoItem = pedidoItem;
        }
    }
}
