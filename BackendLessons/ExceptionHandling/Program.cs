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

            Dictionary<Type, IErrorHandler> excepctionsDictionary = new() {
                [typeof(NotFoundException)] = notFoundExceptionHandler,
                [typeof(DuplicateException)] = duplicateExceptionHandler
            };

            Executor executor = new Executor(excepctionsDictionary);

            executor.Execute(NotFoundTest);
            Console.WriteLine("");
            executor.Execute(DuplicateTest);
        }

        static void NotFoundTest()
        {
            Console.WriteLine("Testing NotFoundException handling:");
            throw new NotFoundException("element not found");
        }

        static void DuplicateTest()
        {
            Console.WriteLine("Testing DuplicateException handling:");
            throw new DuplicateException("Bad request");
        }
    }
}
