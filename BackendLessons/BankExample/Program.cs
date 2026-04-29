namespace BankExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int paymentAmmount = 50;
            int paymentAmmount2 = 150;

            IPaymentProcessor creditCard = new CreditCardPayment();

            IPaymentProcessor bitcoin = new BitcoinPayment();

            creditCard.ProcessPayment(paymentAmmount);

            bitcoin.ProcessPayment(paymentAmmount2);
        }
    }
}
