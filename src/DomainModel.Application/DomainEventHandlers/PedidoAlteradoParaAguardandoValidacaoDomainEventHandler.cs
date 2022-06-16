using DomainModel.Domain.Eventos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainModel.Application.DomainEventHandlers
{
    public class PedidoAlteradoParaAguardandoValidacaoDomainEventHandler
        : INotificationHandler<PedidoAlteradoParaAguardandoValidacaoDomainEvent>
    {
        public Task Handle(PedidoAlteradoParaAguardandoValidacaoDomainEvent notification, CancellationToken cancellationToken)
        {
            //grava log

            //altera entidade

            //adiciona evento de integração

            throw new NotImplementedException();
        }
    }
}
