using ExceptionHandling.Exceptions;
using ExceptionHandling.Handlers;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Dictionary<Type, IErrorHandler> handlers = new()
        {
            { typeof(NotFoundException),  new NotFoundExceptionHandler()  },
            { typeof(DuplicateException), new DuplicateExceptionHandler() }
        };

            Executor executor = new Executor(handlers);

            executor.Execute(NotFoundTest);
            executor.Execute(DuplicateTest);
        }

        static void NotFoundTest()
        {
            throw new NotFoundException("element not found");
        }

        static void DuplicateTest()
        {
            throw new DuplicateException("user already exists");
        }
    }
}
