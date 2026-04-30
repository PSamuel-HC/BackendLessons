using ExceptionHandling.Exceptions;
using ExceptionHandling.Handlers;
using Homework_ExceptionHandling.Enums;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotFoundExceptionHandler notFoundExceptionHandler = new NotFoundExceptionHandler();

            Executor executor = new Executor(new Dictionary<BankErrorCode, IErrorHandler>() {
                {BankErrorCode.NotFound, notFoundExceptionHandler }
            });

            executor.Execute(NotFoundTest);
            //executor.Execute(UnknownExceptionTest);
        }

        static void NotFoundTest()
        {
            throw new NotFoundException("element not found");
        }

        static void UnknownExceptionTest()
        {
            throw new DivideByZeroException();
        }
    }
}
