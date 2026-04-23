using System.Text.Json;

namespace BrokenCode
{
    public class UserProfile
    {
        public required string UserName { get; set; } // added 'required' to avoid warning -> Non-nullable property 'UserName' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the property as nullable.
        public required string Rank { get; set; }
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
            //UserProfile backupUser = primaryUser; // BUG: Reference Copy
            /* Previous line will only create another pointer to the original object. To create a
            Deep copy of the object, nowadays one of the methods is to serialize and
            deserialize the original object. Serializing creates a JSON object based on the original
            object (like extracting its data), and the deserializing it is to create a new
            object with that JSON */
            UserProfile backupUser = JsonSerializer.Deserialize<UserProfile>(JsonSerializer.Serialize(primaryUser))!;

            backupUser.UserName = "Bob";

            Console.WriteLine($"Primary User: {primaryUser.UserName}");
            Console.WriteLine($"Backup User: {backupUser.UserName}");
            // Bug #1 SOLVED!
            // Expecting "Alice", but it will be "Bob". 


            BankTransaction currentTx = new BankTransaction { Amount = 100.00m, IsVerified = false };

            currentTx = ProcessPayment(currentTx);

            Console.WriteLine($"Final Balance: {currentTx.Amount}, Verified: {currentTx.IsVerified}");
            // Bug #2 SOLVED!
            // Expecting 150.00 and True, but will be 100.00 and False.
            /* This error occurs because BankTransaction is a struct, which means, a value data type.
             * So the only way to assign a value that comes from another funtion to this scruct is
             * to have the function return the value and assign it to currentTx */


            // Bug #3 SOLVED!
            // Program Crashes
            /* The function PrintReport is trying to access a non existing property of guestUser because
             * it is pointing to null. To solve this we basically have to actually create a UserProfile
             * object with at least (although both fiels are required now) UserName */
            UserProfile guestUser = new UserProfile { UserName = "Juan", Rank = "Black" };
            PrintReport(guestUser);
        }

        static BankTransaction ProcessPayment(BankTransaction tx)
        {
            tx.Amount += 50.00m;
            tx.IsVerified = true;
            Console.WriteLine("--- Internal: Payment processed successfully! ---");
            return tx;
        }

        static void PrintReport(UserProfile profile)
        {
            Console.WriteLine($"USER REPORT: {profile.UserName.ToUpper()}");
        }
    }
}