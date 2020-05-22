using Proarch.Ems.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Application.Common
{
    public abstract class ExceptionHelper
    {
        protected void ThrowValidationError(string message)
        {
            throw new AppValidationException(message);
        }
    }
}
