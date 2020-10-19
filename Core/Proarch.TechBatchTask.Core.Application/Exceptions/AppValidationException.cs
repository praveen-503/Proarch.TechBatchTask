using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.TechBatchTask.Core.Application.Exceptions
{
    public class AppValidationException : Exception
    {
        public AppValidationException(string message)
            : base(message)
        {

        }
    }
}
