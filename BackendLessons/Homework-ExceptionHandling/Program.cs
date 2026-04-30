using Homework_ExceptionHandling.Enums;
using Homework_ExceptionHandling.Exceptions;
using Homework_ExceptionHandling.Handlers;

namespace Homework_ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotFoundExceptionHandler notFoundExceptionHandler = new NotFoundExceptionHandler();
            DuplicateExceptionHandler duplicateExceptionHandler = new DuplicateExceptionHandler();

            Executor executor = new Executor(new Dictionary<BankErrorCode, IErrorHandler>() {
                {BankErrorCode.NotFound, notFoundExceptionHandler },
                {BankErrorCode.Duplicate, duplicateExceptionHandler }
            });

            executor.Execute(NotFoundTest);
            Console.WriteLine("--------------------------------------------");
            executor.Execute(DuplicateTest);
            Console.WriteLine("--------------------------------------------");
            executor.Execute(UnknownExceptionTest);
        }

        static void NotFoundTest()
        {
            throw new NotFoundException("Element not found");
        }

        static void DuplicateTest()
        {
            throw new DuplicateException("Element already exist");
        }

        static void UnknownExceptionTest()
        {
            throw new DivideByZeroException("Div by 0");
        }
    }
}
