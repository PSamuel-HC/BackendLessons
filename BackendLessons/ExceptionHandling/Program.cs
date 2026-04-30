using ExceptionHandling.Exceptions;
using ExceptionHandling.Handlers;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // STEP 1
            /*
                I replaced the list with ErrorDictionary, a class that have
                Dictionary<int (Exception code), IError (Expected Error)>
                You can check files for more details.
            */
            NotFoundExceptionHandler notFoundExceptionHandler = new();
            DuplicateExceptionHandler duplicateExceptionHandler = new();
            BadRequestExceptionHandler badRequestExceptionHandler = new();
            ErrorDictionary errorDictionary = new()
            {
                { 20, notFoundExceptionHandler },
                { 40, duplicateExceptionHandler },
                { 30, badRequestExceptionHandler },
            };

            Executor executor = new(errorDictionary);

            executor.Execute(NotFoundTest);
            executor.Execute(DuplicatedTest);
            executor.Execute(BadRequestTest);
        }

        static void NotFoundTest()
        {
            throw new NotFoundException("element not found");
        }
        static void DuplicatedTest()
        {
            throw new DuplicateException("element is duplicated");
        }
        static void BadRequestTest()
        {
            throw new BadRequestException("Bad Request, error");
        }
    }
}
