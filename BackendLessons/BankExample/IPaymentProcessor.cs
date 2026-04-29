namespace BankExample
{
    internal interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);

        bool ValidateCredentials();
    }
}
