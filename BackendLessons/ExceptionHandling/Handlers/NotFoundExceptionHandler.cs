using ExceptionHandling.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Handlers
{
    internal class NotFoundExceptionHandler : ErrorHandler
    {
        public override void Handle(ErrorHandlerContext context)
        {
            if (context.CustomException is NotFoundException)
            {
                /// logic to handle

                NotFound();

                context.Handled = true;
            }
        }
    }
}
