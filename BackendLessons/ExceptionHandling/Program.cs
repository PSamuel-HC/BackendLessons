using ExceptionHandling.Exceptions;
using ExceptionHandling.Handlers;
using System;
using System.Collections.Generic;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotFoundExceptionHandler notFoundExceptionHandler = new NotFoundExceptionHandler();
            BadRequestExceptionHandler badRequestExceptionHandler = new BadRequestExceptionHandler();

            // Create a dictionary that maps exception type to the handler instance
            var handlers = new Dictionary<Type, IErrorHandler>
            {
                { typeof(NotFoundException), notFoundExceptionHandler },
                { typeof(BadRequestException), badRequestExceptionHandler }
            };

            // Pass the handler dictionary into the executor
            Executor executor = new Executor(handlers);

            // Execute two tests to verify both exception handlers
            executor.Execute(NotFoundTest);
            executor.Execute(BadRequestTest);
        }

        static void NotFoundTest()
        {
            throw new NotFoundException("element not found");
        }

        static void BadRequestTest()
        {
            throw new BadRequestException("Invalid input data");
        }
    }
}
