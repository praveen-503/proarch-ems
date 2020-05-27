using System;

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
