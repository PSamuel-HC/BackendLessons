using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_ExceptionHandling.Handlers
{
    internal class ErrorHandlerContext
    {
        public Exception CustomException { get; }

        public bool Handled { get; set; }

        public List<string> ErrorMessages { get; set; } = new List<string>();

        public ErrorHandlerContext(Exception exception)
        {
            CustomException = exception;
        }
    }
}
