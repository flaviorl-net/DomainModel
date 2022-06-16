using DomainModel.Domain.Entities;
using DomainModel.DomainCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Domain.Validation
{
    public class PedidoItemValidation : FiscalBase<PedidoItem>
    {
        public PedidoItemValidation()
        {
            var quantidadePedidoItemValidation = new QuantidadePedidoItemValidation();
            var descontoPedidoItemValidation = new DescontoPedidoItemValidation();

            base.AddRule("quantidadePedidoItemValidation", new Rule<PedidoItem>(quantidadePedidoItemValidation, "Quantidade inválida"));
            base.AddRule("descontoPedidoItemValidation", new Rule<PedidoItem>(descontoPedidoItemValidation, "O total do item do pedido é menor que o desconto aplicado"));
        }
    }
}