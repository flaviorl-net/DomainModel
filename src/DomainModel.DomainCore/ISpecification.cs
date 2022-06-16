using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.DomainCore
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
