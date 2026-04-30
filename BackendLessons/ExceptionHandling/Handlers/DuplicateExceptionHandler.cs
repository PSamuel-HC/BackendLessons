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
                /// logic to handle

                BadRequest(context.ErrorMessages);

                context.Handled = true;
            }
        }
    }
}
