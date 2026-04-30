using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Handlers
{
    internal class ErrorHandlerContext
    {
        public Exception CustomException { get; }

        // Marks whether the exception has been handled
        public bool Handled { get; set; }

        // Store error messages that handlers can add
        public List<string> ErrorMessages { get; } = new List<string>();

        public ErrorHandlerContext(Exception exception)
        {
            CustomException = exception;
        }
    }
}
