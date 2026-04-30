using System;
using System.Collections.Generic;
using System.Text;


namespace ExceptionHandling.Handlers
{
    internal class ErrorHandlerContext
    {
        public Exception CustomException { get; }

        public bool Handled { get; set; }

        public ErrorHandlerContext(Exception exception)
        {
            CustomException = exception;
        }
    }
}
