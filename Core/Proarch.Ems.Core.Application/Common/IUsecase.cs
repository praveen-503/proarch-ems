using Proarch.Ems.Core.Domain.Exceptions;

namespace Proarch.Ems.Core.Application.Common
{
    public interface IUsecase
    {
    }

    public abstract class Usecase : IUsecase
    {
        protected void ThrowValidationError(string message)
        {
            throw new AppValidationException(message);
        }
    }
}
