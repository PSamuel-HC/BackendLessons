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
            Console.WriteLine("Bug 1: Reference Type\n");

            UserProfile primaryUser = new UserProfile { UserName = "Alice", Rank = "Gold" };

            // FIX: create a new object instead of copying the reference.
            // This works because classes share the same reference when assigned,
            // so creating a new instance makes them independent.
            UserProfile backupUser = new UserProfile
            {
                UserName = primaryUser.UserName,
                Rank = primaryUser.Rank
            };

            backupUser.UserName = "Bob";

            Console.WriteLine($"Primary User: {primaryUser.UserName}");
            Console.WriteLine($"Backup User: {backupUser.UserName}");

            Console.WriteLine("\n-----------------------------\n");


            Console.WriteLine("Bug 2: Value Type\n");

            BankTransaction currentTx = new BankTransaction { Amount = 100.00m, IsVerified = false };

            // FIX: pass the struct using ref so the original value is modified.
            // This works because structs are copied by default when passed to methods,
            // and ref forces the method to use the original variable.
            ProcessPayment(ref currentTx);

            Console.WriteLine($"Final Balance: {currentTx.Amount}, Verified: {currentTx.IsVerified}");

            Console.WriteLine("\n-----------------------------\n");


            Console.WriteLine("Bug 3: Null\n");

            UserProfile guestUser = null;

            // FIX: check for null before using the object.
            // This works because accessing a null object causes a runtime exception,
            // so validating prevents the crash.
            PrintReport(guestUser);

            Console.WriteLine("\n-----------------------------\n");
        }

        static void ProcessPayment(ref BankTransaction tx)
        {
            tx.Amount += 50.00m;
            tx.IsVerified = true;
            Console.WriteLine("--- Payment processed ---");
        }

        static void PrintReport(UserProfile profile)
        {
            // FIX: prevent null reference access
            if (profile == null)
            {
                Console.WriteLine("USER REPORT: Unknown Guest User");
                return;
            }

            Console.WriteLine($"USER REPORT: {profile.UserName.ToUpper()}");
        }
    }
}