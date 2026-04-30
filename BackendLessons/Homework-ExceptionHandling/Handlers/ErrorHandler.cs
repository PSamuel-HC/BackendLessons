using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_ExceptionHandling.Handlers
{
    internal abstract class ErrorHandler : IErrorHandler
    {
        public abstract void Handle(ErrorHandlerContext context);

        public void NotFound()
        {
            Console.WriteLine("Element not found");
        }

        public void BadRequest(List<string> errorMessages)
        {
            Console.WriteLine("Bad Request");
            Console.WriteLine("Bad Request Errors:");
            for (int i = 0; i < errorMessages.Count; ++i)
            {
                Console.WriteLine($"{i}: {errorMessages[i]}");
            }
        }
    }
}
