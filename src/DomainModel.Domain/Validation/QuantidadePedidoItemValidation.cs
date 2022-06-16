using DomainModel.Domain.Entities;
using DomainModel.DomainCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Domain.Validation
{
    public class QuantidadePedidoItemValidation : ISpecification<PedidoItem>
    {
        public bool IsSatisfiedBy(PedidoItem entity)
        {
            if (entity.Quantidade < 1)
            {
                return false;
            }

            return true;
        }
    }
}
