using ExceptionHandling.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Handlers
{
    internal class BadRequestExceptionHandler : ErrorHandler
    {
        public override void Handle(ErrorHandlerContext context)
        {
            if (context.CustomException is BadRequestException)
            {

                // STEP 3 SIMULATING FAILED MESSAGES
                context.AddFailedMessage();
                context.AddFailedMessage();
                context.AddFailedMessage();

                context.ShowMessages();

                BadRequest();

                context.Handled = true;
            }
        }
    }
}
