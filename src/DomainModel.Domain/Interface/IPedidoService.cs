using DomainModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Domain.Interface
{
    public interface IPedidoService
    {
        void CriarPedido(Pedido pedido);
    }
}
