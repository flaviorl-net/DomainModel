using DomainModel.Domain.Entities;
using MediatR;

namespace DomainModel.Domain.Eventos
{
    public class PedidoCanceladoDomainEvent : INotification
    {
        public Pedido Pedido { get; }

        public PedidoCanceladoDomainEvent(Pedido pedido)
        {
            Pedido = pedido;
        }
    }
}
