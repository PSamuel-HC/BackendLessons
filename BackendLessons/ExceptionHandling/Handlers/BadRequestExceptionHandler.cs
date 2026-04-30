using ExceptionHandling.Exceptions;

namespace ExceptionHandling.Handlers
{
    internal class BadRequestExceptionHandler : ErrorHandler
    {
        public override void Handle(ErrorHandlerContext context)
        {
            if (context.CustomException is BadRequestException badRequestException)
            {
                // Add the exception message to the error context
                context.ErrorMessages.Add(badRequestException.Message);

                // Print the bad request output using the messages list
                BadRequest(context.ErrorMessages);
                context.Handled = true;
            }
        }
    }
}
