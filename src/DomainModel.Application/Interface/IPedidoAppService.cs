using DomainModel.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Application.Interface
{
    public interface IPedidoAppService
    {
        public void CriarPedidoServiceDomain(CriarPedidoViewModel criarPedidoViewModel);

        public void CriarPedido(CriarPedidoViewModel criarPedidoViewModel);
    }
}
