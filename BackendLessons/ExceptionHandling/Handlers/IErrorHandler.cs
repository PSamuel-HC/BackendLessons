namespace ExceptionHandling.Handlers
{
    internal interface IErrorHandler
    {
        void Handle(ErrorHandlerContext context);
    }
}
