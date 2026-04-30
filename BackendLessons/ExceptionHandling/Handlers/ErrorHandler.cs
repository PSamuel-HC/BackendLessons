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
            Console.WriteLine("Error 404: Element not found");
        }

        public void BadRequest(List<string> errorMessages)
        {
            foreach(string msg in errorMessages)
            {
                Console.WriteLine(msg);
            }
        }
    }
}
