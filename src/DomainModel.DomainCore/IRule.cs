using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.DomainCore
{
    public interface IRule<in TEntity>
    {
        string ErrorMessage { get; }
        bool Validate(TEntity entity);
    }
}
