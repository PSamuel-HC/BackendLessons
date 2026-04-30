using Homework_ExceptionHandling.Enums;

namespace ExceptionHandling.Exceptions
{
    internal abstract class BankPlatformException : Exception
    {
        public abstract BankErrorCode ErrorCode { get; }

        public BankPlatformException(string message) : base(message)
        {

        }
    }
}
