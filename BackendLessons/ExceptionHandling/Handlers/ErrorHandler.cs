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
            errorMessages.ForEach(x => Console.WriteLine("Error: " + x + "\n"));
        }
        //I am printing all the errors received.
    }
}
