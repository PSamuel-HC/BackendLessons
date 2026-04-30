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
        // Step 2: I added Duplicate ad
        public void Duplicated()
        {
            Console.WriteLine("Element is duplicated");
        }

        public void BadRequest()
        {
            Console.WriteLine("Bad Request");
        }
    }
}
