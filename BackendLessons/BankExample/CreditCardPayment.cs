namespace BankExample
{
    internal class CreditCardPayment : BasePayment
    {
        public override bool ValidateCredentials()
        {
            Console.WriteLine("Checking Credit Card CVV and Expiry...");
            return true;
        }

        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Charging ${amount} to Visa/Mastercard.");
        }
    }
}
