using DomainModel.Domain.Entities;
using DomainModel.DomainCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Domain.Validation
{
    public class DescontoPedidoItemValidation : ISpecification<PedidoItem>
    {
        public bool IsSatisfiedBy(PedidoItem entity)
        {
            if ((entity.PrecoUnitario * entity.Quantidade) < entity.Desconto)
            {
                return false;
            }

            return true;
        }
    }
}