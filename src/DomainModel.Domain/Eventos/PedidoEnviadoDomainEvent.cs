using DomainModel.Domain.Entities;
using MediatR;

namespace DomainModel.Domain.Eventos
{
    public class PedidoEnviadoDomainEvent : INotification
    {
        public Pedido Pedido { get; }

        public PedidoEnviadoDomainEvent(Pedido pedido)
        {
            Pedido = pedido;
        }
    }
}
