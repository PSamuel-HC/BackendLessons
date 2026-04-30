namespace BankExample
{
    public abstract class BasePayment : IPaymentProcessor
    {
        public string TransactionId { get; private set; }

        public abstract int ErrorCode { get; } 

        protected BasePayment()
        {
            TransactionId = Guid.NewGuid().ToString();
        }

        public void LogTransaction()
        {
            Console.WriteLine($"[LOG] ID: {TransactionId} at {DateTime.Now}");
        }

        // These stay abstract because the 'Child' must define them.
        public abstract void ProcessPayment(decimal amount);
        public abstract bool ValidateCredentials();

    }
}
