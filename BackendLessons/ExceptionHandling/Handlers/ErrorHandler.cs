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

        public void BadRequest(List<string> errorMessages)
        {
            Console.WriteLine("Bad Request:");
            foreach (string message in errorMessages)
            {
                Console.WriteLine(message);
            }
        }
    }
}
