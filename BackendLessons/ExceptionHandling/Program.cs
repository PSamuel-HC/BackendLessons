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

            Dictionary<int, IErrorHandler> excepctionsDictionary = new()
            {
                [ErrorCodes.NotFound] = notFoundExceptionHandler,
                [ErrorCodes.Duplicate] = duplicateExceptionHandler
            };

            Executor executor = new Executor(excepctionsDictionary);

            executor.Execute(NotFoundTest);
            executor.Execute(DuplicateTest);
        }

        static void NotFoundTest()
        {
            throw new NotFoundException("Element not found");
        }
        static void DuplicateTest()
        {
            throw new DuplicateException("Duplicate element");
        }
    }
}
