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

                BadRequest(context.ErrorMessages);  //I am passing the errors stored in the context
                context.Handled = true;
            }
        }
    }
}
