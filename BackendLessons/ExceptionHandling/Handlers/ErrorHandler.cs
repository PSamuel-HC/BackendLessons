using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Handlers
{
    internal abstract class ErrorHandler : IErrorHandler
    {
        public abstract void Handle(ErrorHandlerContext context);

        public void NotFound()
        {
            Console.WriteLine("Element not found");
        }

        // Print Bad Request and all accumulated messages
        public void BadRequest(List<string> messages)
        {
            Console.WriteLine("Bad Request");
            foreach (var message in messages)
            {
                Console.WriteLine($"- {message}");
            }
        }
    }
}
