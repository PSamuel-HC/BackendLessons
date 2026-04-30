namespace ExceptionHandling.Exceptions
{
    internal class DuplicateException : BankPlatformException
    {
        public override int ErrorCode => ErrorCodes.Duplicate;


        public DuplicateException(string message) : base(message)
        {
        }

    }
}
