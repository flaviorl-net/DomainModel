using DomainModel.Domain.Eventos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainModel.Application.DomainEventHandlers
{
    public class PedidoAlteradoParaEstoqueConfirmadoDomainEventHandler
        : INotificationHandler<PedidoAlteradoParaEstoqueConfirmadoDomainEvent>
    {
        public Task Handle(PedidoAlteradoParaEstoqueConfirmadoDomainEvent notification, CancellationToken cancellationToken)
        {
            //grava log

            //altera entidade

            //adiciona evento de integração

            throw new NotImplementedException();
        }
    }
}
