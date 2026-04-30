using ExceptionHandling.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Handlers
{
    internal class DuplicateExceptionHandler : ErrorHandler
    {
        public override void Handle(ErrorHandlerContext context)
        {
            if (context.CustomException is DuplicateException)
            {
                DuplicateException exception = (DuplicateException)context.CustomException;
                int errorCode = exception.ErrorCode;
                BadRequest(new List<string> () { $"Error {errorCode}: Bad Request",
                    "Duplicate entries",
                    context.CustomException.Message
                });

                context.Handled = true;
            }
        }
    }
}
