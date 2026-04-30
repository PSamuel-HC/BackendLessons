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
            if (context.CustomException is DuplicateException ex)
            {
                var messages = new List<string>
                {
                    "Element already exists.",
                    ex.Message
                };

                BadRequest(messages);
                context.Handled = true;
            }
        }
    }
}