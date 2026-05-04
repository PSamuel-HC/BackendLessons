using ExceptionHandling.Exceptions;
using ExceptionHandling.Handlers;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Executor executor = new Executor(new Dictionary<Type, IErrorHandler>()
            {
                { typeof(NotFoundException), new NotFoundExceptionHandler() },
                { typeof(DuplicateException), new DuplicateExceptionHandler() }
            });

            executor.Execute(NotFoundTest);
            executor.Execute(DuplicateTest);
        }

        static void NotFoundTest()
        {
            throw new NotFoundException("element not found");
        }

        static void DuplicateTest()
        {
            throw new DuplicateException("duplicate entry detected", new List<string>
            {
                "Email already exists",
                "Username already taken"
            });
        }
    }
}
