using ExceptionHandling.Exceptions;

namespace ExceptionHandling.Handlers
{
    internal class DuplicateExceptionHandler : ErrorHandler
    {
        public override void Handle(ErrorHandlerContext context)
        {
            if (context.CustomException is DuplicateException ex)
            {
                context.ErrorMessages = ex.Errors;
                BadRequest(context.ErrorMessages);
                context.Handled = true;
            }
        }
    }
}
