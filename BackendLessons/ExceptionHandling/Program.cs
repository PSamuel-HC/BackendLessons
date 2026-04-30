using ExceptionHandling.Exceptions;
using ExceptionHandling.Handlers;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotFoundExceptionHandler notFoundExceptionHandler = new NotFoundExceptionHandler();
            //NotFoundException notFoundException = new NotFoundException("Element not found");

            Dictionary<Type, IErrorHandler> excepctionsDictionary = new() { [typeof(NotFoundException)] = notFoundExceptionHandler };

            Executor executor = new Executor(excepctionsDictionary);

            executor.Execute(NotFoundTest);
        }

        static void NotFoundTest()
        {
            throw new NotFoundException("element not found");
        }
    }
}
