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
                BadRequest(new List<string> () { "Error 400: Bad Request", "Duplicate entries" });

                context.Handled = true;
            }
        }
    }
}
