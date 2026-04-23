namespace BrokenCode
{
    public struct UserProfile
    {
        public string UserName { get; set; }
        public string Rank { get; set; }
    }


    public class BankTransaction
    {
        public decimal Amount;
        public bool IsVerified;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bug 1: Convert Class to Struct\n");
            UserProfile primaryUser = new UserProfile { UserName = "Alice", Rank = "Gold" };
            UserProfile backupUser = primaryUser; // BUG: Reference Copy
            backupUser.UserName = "Bob";
            Console.WriteLine($"Primary User: {primaryUser.UserName}");
            // Bug #1
            // Expecting "Alice", but it will be "Bob".

            // ------------------------------------------
            // ------------------------------------------
            /*
                I have changed the Type of USER PROFILE of Class to Struct
                because I needed that the object needed to be stored in
                Stack without any Heap Reference
            */
            // ------------------------------------------
            // ------------------------------------------
            Console.WriteLine("\n\n\n");




            Console.WriteLine("Bug 2: Convert Struct to Class\n");
            BankTransaction currentTx = new BankTransaction { Amount = 100.00m, IsVerified = false };
            ProcessPayment(currentTx);
            Console.WriteLine($"Final Balance: {currentTx.Amount}, Verified: {currentTx.IsVerified}");
            // Bug #2
            // Expecting 150.00 and True, but will be 100.00 and False.

            // ------------------------------------------
            // ------------------------------------------
            /*
                I have changed the Type of BANK TRANSACTION of Struct to Class
                Because I needed that the object conserves its reference saving
                it in Heap Memory
            */
            // ------------------------------------------
            // ------------------------------------------
            Console.WriteLine("\n\n\n");



            Console.WriteLine("Bug 3: Nullable Elements\n");
            // Bug #3
            // Program Crashes
            UserProfile? guestUser = null;
            PrintReport(guestUser);

            // ------------------------------------------
            // ------------------------------------------
            /*
                I change types with nullable options with ?
                UserProfile? in the program Class and PrintReport function
                PRINT REPORT function has been changed
            */
            // ------------------------------------------
            // ------------------------------------------

            Console.WriteLine("\n\n\n");
        }

        static void ProcessPayment(BankTransaction tx)
        {
            tx.Amount += 50.00m;
            tx.IsVerified = true;
            Console.WriteLine("--- Internal: Payment processed successfully! ---");
        }

        static void PrintReport(UserProfile? profile)
        {
            Console.WriteLine($"USER REPORT: { profile?.UserName?.ToUpper() ?? "Unknown Guest User"}");
        }
    }
}