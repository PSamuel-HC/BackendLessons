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
            UserProfile backupUser = new UserProfile { UserName = primaryUser.UserName, Rank = primaryUser.Rank };

            backupUser.UserName = "Bob";

            Console.WriteLine($"Primary User: {primaryUser.UserName}");
            // Bug #1
            // Expecting "Alice", but it will be "Bob".

            // SOLUTION:
            // Since UserProfile is a class, it create a reference to the same instace rather than a real copy.
            // The solution was creating a new instance of UserProfile with the primaryUser attributes.

            BankTransaction currentTx = new BankTransaction { Amount = 100.00m, IsVerified = false };

            ProcessPayment(ref currentTx);

            Console.WriteLine($"Final Balance: {currentTx.Amount}, Verified: {currentTx.IsVerified}");
            // Bug #2
            // Expecting 150.00 and True, but will be 100.00 and False.

            // SOLUTION:
            // Since BankTransaction is a struct, the tx parameter was receiving a copy of the currentTx instace
            // and the attribute updating code inside the method was affecting only the copy of the the original instance.
            // The solution was adding the ref keyword that would pass the memory address of the struct rather than a copy of its data.


            // Bug #3
            // Program Crashes

            // SOLUTION:
            // Since the class guestUser is being instanciated as null, the stack pointer is pointing to an invalid memory address of the heap.
            // In the PrintReport, the profile parameter is referencing the same null memory address.
            // Finally accessing this null address to get a UserName attribute results in a crash of the program
            // The solution was adding a conditional to check if profile is not null to know if we can access UserName attribute.

            UserProfile guestUser = null;
            PrintReport(guestUser);
        }

        static void ProcessPayment(ref BankTransaction tx)
        {
            tx.Amount += 50.00m;
            tx.IsVerified = true;
            Console.WriteLine("--- Internal: Payment processed successfully! ---");
        }

        static void PrintReport(UserProfile profile)
        {
            if (profile != null) {
                Console.WriteLine($"USER REPORT: {profile.UserName.ToUpper()}");
            }
            else {
                Console.WriteLine($"PROFILE IS NULL");
            }
        }
    }
}