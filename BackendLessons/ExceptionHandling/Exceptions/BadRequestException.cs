namespace ExceptionHandling.Exceptions
{
    internal class BadRequestException : BankPlatformException
    {
        public override int ErrorCode => 40;

        public BadRequestException(string message) : base(message)
        {
        }
    }
}
