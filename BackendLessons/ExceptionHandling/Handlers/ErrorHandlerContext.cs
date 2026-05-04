namespace ExceptionHandling.Handlers
{
    internal class ErrorHandlerContext
    {
        public Exception CustomException { get; }

        public bool Handled { get; set; }

        public List<string> ErrorMessages { get; set; } = new();

        public ErrorHandlerContext(Exception exception)
        {
            CustomException = exception;
        }
    }
}
