namespace ExceptionHandling.Exceptions
{
    internal class DuplicateException : BankPlatformException
    {
        public override int ErrorCode => 409;


        public DuplicateException(string message) : base(message)
        {
        }

    }
}
