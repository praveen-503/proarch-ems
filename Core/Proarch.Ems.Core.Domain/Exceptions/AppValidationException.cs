using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Domain.Exceptions
{
    public class AppValidationException : Exception
    {
        public AppValidationException(string message)
            : base(message)
        {

        }
    }
}
