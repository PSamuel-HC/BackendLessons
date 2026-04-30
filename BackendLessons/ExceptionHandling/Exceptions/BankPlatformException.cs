namespace ExceptionHandling.Exceptions
{
    internal abstract class BankPlatformException : Exception
    {
        public abstract short ErrorCode { get; }

        public List<string> Messages { get; private set; } = new List<string>();

        /*
         I've added a list of messages so I can work with multiple errors in the context
         */
        public BankPlatformException(string message) : base(message)
        {
           
        }
        public BankPlatformException(string message, List<string> messages ) : base(message) 
        {
            Messages = messages;
        }
        //I overloaded the constructors
    }
}
