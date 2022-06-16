using DomainModel.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace DomainModel.Domain.Eventos
{
    public class PedidoAlteradoParaAguardandoValidacaoDomainEvent : INotification
    {
        public int PedidoId { get; }
        public IEnumerable<PedidoItem> PedidoItem { get; }

        public PedidoAlteradoParaAguardandoValidacaoDomainEvent(int pedidoId,
            IEnumerable<PedidoItem> pedidoItem)
        {
            PedidoId = pedidoId;
            PedidoItem = pedidoItem;
        }
    }
}
