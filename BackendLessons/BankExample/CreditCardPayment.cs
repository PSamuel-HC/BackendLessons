namespace BankExample
{
    internal class CreditCardPayment : BasePayment
    {
        public override int ErrorCode => 5;

        public override bool ValidateCredentials()
        {
            Console.WriteLine("Checking Credit Card CVV and Expiry...");
            return true;
        }

        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Charging ${amount} to Visa/Mastercard.");
        }

        public void Test()
        {
            Excecute(() => ProcessPayment(8));
        }

        public void Excecute(Action action)
        {
            action.Invoke();
        }
    }
}
