namespace ExceptionHandling.Exceptions
{
    internal class DuplicateException : BankPlatformException
    {
        public override int ErrorCode => 40;

        public List<string> Errors { get; }

        public DuplicateException(string message, List<string> errors) : base(message)
        {
            Errors = errors;
        }
    }
}
