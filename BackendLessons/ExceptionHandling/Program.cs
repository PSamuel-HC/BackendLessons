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

            Dictionary<Type, IErrorHandler> excepctionsDictionary = new()
            {
                [typeof(NotFoundException)] = notFoundExceptionHandler,
                [typeof(DuplicateException)] = duplicateExceptionHandler
            };

            Executor executor = new Executor(excepctionsDictionary);

            executor.Execute(NotFoundTest);
            executor.Execute(DuplicateTest);
        }

        static void NotFoundTest()
        {
            throw new NotFoundException("element not found");
        }
        static void DuplicateTest()
        {
            throw new DuplicateException("duplicate element");
        }
    }
}
