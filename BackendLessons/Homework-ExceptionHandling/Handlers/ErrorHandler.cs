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

        public void BadRequest()
        {
            Console.WriteLine("Bad Request");
        }
    }
}
