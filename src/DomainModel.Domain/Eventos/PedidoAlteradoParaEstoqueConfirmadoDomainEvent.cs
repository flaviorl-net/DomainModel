using MediatR;

namespace DomainModel.Domain.Eventos
{
    public class PedidoAlteradoParaEstoqueConfirmadoDomainEvent : INotification
    {
        public int PedidoId { get; }

        public PedidoAlteradoParaEstoqueConfirmadoDomainEvent(int pedidoId)
            => PedidoId = pedidoId;
    }
}
