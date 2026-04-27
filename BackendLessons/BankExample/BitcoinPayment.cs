namespace BankExample
{
    internal class BitcoinPayment : BasePayment
    {
        public override bool ValidateCredentials()
        {
            Console.WriteLine("Verifying Wallet Address on Blockchain...");
            return true;
        }

        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Transferring {amount / 60000} BTC...");
        }
    }
}
