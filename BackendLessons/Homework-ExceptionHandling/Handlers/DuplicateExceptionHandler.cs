using Homework_ExceptionHandling.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_ExceptionHandling.Handlers
{
    internal class DuplicateExceptionHandler : ErrorHandler
    {
        public override void Handle(ErrorHandlerContext context)
        {
            if (context.CustomException is DuplicateException)
            {
                context.ErrorMessages.Add(context.CustomException.Message);
                BadRequest(context.ErrorMessages);
                context.Handled = true;
            }
        }
    }
}
