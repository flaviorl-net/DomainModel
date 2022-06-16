using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.DomainCore
{
    public interface IFiscal<in TEntity>
    {
        ValidationResult Validate(TEntity entity);
    }
}
