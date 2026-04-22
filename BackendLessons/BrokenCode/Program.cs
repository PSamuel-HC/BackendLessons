namespace BrokenCode
{
    public class UserProfile
    {
        public string UserName { get; set; }
        public string Rank { get; set; }
    }

    public struct BankTransaction
    {
        public decimal Amount;
        public bool IsVerified;
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserProfile primaryUser = new UserProfile { UserName = "Alice", Rank = "Gold" };
            UserProfile backupUser = primaryUser; // BUG: Reference Copy

            backupUser.UserName = "Bob";

            Console.WriteLine($"Primary User: {primaryUser.UserName}");
            // Bug #1
            // Expecting "Alice", but it will be "Bob".


            BankTransaction currentTx = new BankTransaction { Amount = 100.00m, IsVerified = false };

            ProcessPayment(currentTx);

            Console.WriteLine($"Final Balance: {currentTx.Amount}, Verified: {currentTx.IsVerified}");
            // Bug #2
            // Expecting 150.00 and True, but will be 100.00 and False.


            // Bug #3
            // Program Crashes
            UserProfile guestUser = null;
            PrintReport(guestUser);
        }

        static void ProcessPayment(BankTransaction tx)
        {
            tx.Amount += 50.00m;
            tx.IsVerified = true;
            Console.WriteLine("--- Internal: Payment processed successfully! ---");
        }

        static void PrintReport(UserProfile profile)
        {
            Console.WriteLine($"USER REPORT: {profile.UserName.ToUpper()}");
        }
    }
}