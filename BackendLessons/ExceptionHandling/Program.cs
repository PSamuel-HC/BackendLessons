using ExceptionHandling.Exceptions;
using ExceptionHandling.Handlers;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotFoundExceptionHandler notFoundExceptionHandler = new NotFoundExceptionHandler();

            Executor executor = new Executor(new List<IErrorHandler>() { notFoundExceptionHandler });

            executor.Execute(NotFoundTest);
        }

        static void NotFoundTest()
        {
            throw new NotFoundException("element not found");
        }
    }
}
