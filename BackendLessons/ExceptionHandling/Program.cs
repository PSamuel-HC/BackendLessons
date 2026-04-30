using ExceptionHandling.Constants;
using ExceptionHandling.Exceptions;
using ExceptionHandling.Handlers;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var handlers = new Dictionary<int, IErrorHandler>
            {
                { ErrorCodes.NotFound, new NotFoundExceptionHandler() },
                { ErrorCodes.Duplicate, new DuplicateExceptionHandler() }
            };

            var executor = new Executor(handlers);

            Console.WriteLine("not found test");
            executor.Execute(() => throw new NotFoundException("User not found"));

            Console.WriteLine("Duplicate test");
            executor.Execute(() => throw new DuplicateException("User already exists"));
        }
    }
}
