using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.DomainCore
{
    public class ValidationError
    {
        public string Message { get; set; }
        public ValidationError(string message)
        {
            this.Message = message;
        }
    }
}
