using DomainModel.Domain.Entities;
using DomainModel.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public void CriarPedido(Pedido pedido)
        {
            _pedidoRepository.Add(pedido);
        }
    }
}