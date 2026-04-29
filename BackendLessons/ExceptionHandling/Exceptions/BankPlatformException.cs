namespace ExceptionHandling.Exceptions
{
    internal abstract class BankPlatformException : Exception
    {
        public abstract int ErrorCode { get; }

        public BankPlatformException(string message) : base(message)
        {

        }
    }
}
