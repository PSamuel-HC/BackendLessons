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
                List<string> errors = new List<string>
                {
                    "duplicate entry",
                    context.CustomException.Message
                };
                BadRequest(errors);
                context.Handled = true;
            }
        }
    }
}
