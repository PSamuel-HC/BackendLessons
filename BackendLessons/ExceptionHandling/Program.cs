using ExceptionHandling.Errors;
using ExceptionHandling.Exceptions;
using ExceptionHandling.Handlers;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotFoundExceptionHandler notFoundExceptionHandler = new NotFoundExceptionHandler();
            DuplicateExceptionHandler duplicateExceptionHandler = new DuplicateExceptionHandler();

            Dictionary<short, IErrorHandler> handlers = new Dictionary<short, IErrorHandler>();

            handlers.Add(ErrorCodes.NotFoundError, notFoundExceptionHandler); //I am reusing the codes from the static errors class
            handlers.Add(ErrorCodes.DuplicateError, duplicateExceptionHandler);//This is how handlers can be identified

            Executor executor = new Executor(handlers);

            //executor.Execute(NotFoundTest);

            executor.Execute(DuplicateException);
        }

        static void NotFoundTest()
        {
            throw new NotFoundException("element not found");
        }

        static void DuplicateException()
        {
            //I'm sending a list of errors to verify functionality
            throw new DuplicateException("Duplicated", ["Email already exists", "Name already exists", "Username already exists"]);

        }
    }
}
