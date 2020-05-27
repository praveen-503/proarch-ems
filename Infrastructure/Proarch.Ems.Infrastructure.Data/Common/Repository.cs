using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Core.Application.Common;
using Proarch.Ems.Core.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace Proarch.Ems.Infrastructure.Data.Common
{
    public abstract class Repository : IRepository
    {
        protected void ThrowValidationError(string message)
        {
            throw new AppValidationException(message);
        }


        protected async Task TryUpdateAsync(Func<Task> action)
        {
            try
            {
                await action?.Invoke();
            }
            catch (DbUpdateConcurrencyException)
            {
                ThrowValidationError("Operation failed because another user has updated or delete the record.");
            }
        }
    }
}
