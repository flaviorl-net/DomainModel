using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.DomainCore
{
    public interface ISelfValidator
    {
        ValidationResult IsValid();
    }
}
