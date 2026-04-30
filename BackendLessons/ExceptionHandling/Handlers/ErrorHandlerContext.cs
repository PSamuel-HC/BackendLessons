using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Handlers
{
    internal class ErrorHandlerContext
    {
        public Exception CustomException { get; }

        public bool Handled { get; set; }

        public List<string> ErrorMessages { get; set;} =new List<string>();
        //I've added the error list to allow multiple messages

        public ErrorHandlerContext(Exception exception)
        {
            CustomException = exception;
        }
        public ErrorHandlerContext(Exception exception, List<string> errors)
        {
            CustomException = exception;
            ErrorMessages = errors;
        }
    }
}
