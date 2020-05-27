using Proarch.Ems.Core.Domain.Exceptions;

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
