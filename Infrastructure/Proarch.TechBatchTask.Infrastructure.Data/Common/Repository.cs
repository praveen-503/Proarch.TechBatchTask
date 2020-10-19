using Microsoft.EntityFrameworkCore;
using Proarch.TechBatchTask.Core.Application.Common;
using Proarch.TechBatchTask.Core.Application.Exceptions;
using System;
using System.Threading.Tasks;

namespace Proarch.TechBatchTask.Infrastructure.Data.Common
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
