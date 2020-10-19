using Proarch.TechBatchTask.Core.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.TechBatchTask.Core.Application.Common
{
    public abstract class ExceptionHelper
    {
        protected void ThrowValidationError(string message)
        {
            throw new AppValidationException(message);
        }
    }
}
