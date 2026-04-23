using System;

namespace FixedCode
{
    public class UserProfile
    {
        public string UserName { get; set; }
        public string Rank { get; set; }

        // Helper method to create an independent copy of the object.
        public UserProfile Clone()
        {
            return new UserProfile
            {
                UserName = this.UserName,
                Rank = this.Rank
            };
        }
    }

    // BankTransaction is now a CLASS (reference type) instead of a struct.
    public class BankTransaction
    {
        public decimal Amount { get; set; }
        public bool IsVerified { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // FIX #1: Reference copy vs value copy
            // Original problem: "backupUser = primaryUser" copied the
            // reference, not the object, so modifying one modified the other.
            // Solution: create a NEW object with the same values.
            UserProfile primaryUser = new UserProfile { UserName = "Alice", Rank = "Gold" };
            UserProfile backupUser = primaryUser.Clone(); // independent copy

            backupUser.UserName = "Bob";

            Console.WriteLine($"Primary User: {primaryUser.UserName}"); // Alice
            Console.WriteLine($"Backup User:  {backupUser.UserName}");  // Bob


            // FIX #2: Struct passed by value to a method
            // Original problem: BankTransaction was a struct (value type),
            // so the method received a COPY and the changes were lost.
            // Solution: convert BankTransaction into a class (reference type)
            // so modifications inside the method affect the original object.
            // Alternative 1: keep it as struct and pass it with "ref".
            // Alternative 2: keep it as struct and return the modified copy from the method.
            BankTransaction currentTx = new BankTransaction { Amount = 100.00m, IsVerified = false };

            ProcessPayment(currentTx);

            Console.WriteLine($"Final Balance: {currentTx.Amount}, Verified: {currentTx.IsVerified}");
            // Now prints: 150.00 and True

            // FIX #3: NullReferenceException
            // Original problem: PrintReport accessed profile.UserName without
            // checking whether profile was null.
            // Solution: validate null before using the object, and use the
            // ?. operator in case UserName is also null.
            UserProfile guestUser = null;
            PrintReport(guestUser);

            UserProfile realUser = new UserProfile { UserName = "Carla", Rank = "Silver" };
            PrintReport(realUser);
        }

        static void ProcessPayment(BankTransaction tx)
        {
            tx.Amount += 50.00m;
            tx.IsVerified = true;
            Console.WriteLine("--- Internal: Payment processed successfully! ---");
        }

        static void PrintReport(UserProfile profile)
        {
            if (profile == null)
            {
                Console.WriteLine("USER REPORT: (no user)");
                return;
            }

            string name = profile.UserName?.ToUpper() ?? "(NO NAME)";
            Console.WriteLine($"USER REPORT: {name}");
        }
    }
}