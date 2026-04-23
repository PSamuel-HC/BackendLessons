using static System.Net.Mime.MediaTypeNames;

namespace BrokenCode
{
    // Change class by struct
    public struct UserProfile
    {
        public string UserName { get; set; }
        public string Rank { get; set; }
    }

    // This ClassUserProfile was created to be able to see bug 3,
    // because when changing UserProfile to struct, it was not allowed to create a null UserProfile
    public class ClassUserProfile
    {
        public string UserName { get; set; }
        public string Rank { get; set; }
    }

    // Change struct by class
    public class BankTransaction
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

            // SOLUTION !
            // The class was changed to a struct to prevent copying by reference.
            // Now assignments create separate copies(by value),
            // preventing changes to backupUser from affecting primaryUser.



            // Another solution is to create a new instance of the UserProfile with the data from the PrimaryUser.
            // This avoids referencing the PrimaryUser.

            // UserProfile backupUser = new UserProfile { UserName = primaryUser.UserName, Rank = primaryUser.Rank };
            // backupUser.UserName = "Bob";
            // Console.WriteLine($"Primary User: {primaryUser.UserName}");



            BankTransaction currentTx = new BankTransaction { Amount = 100.00m, IsVerified = false };

            ProcessPayment(currentTx);

            Console.WriteLine($"Final Balance: {currentTx.Amount}, Verified: {currentTx.IsVerified}");

            // Bug #2
            // Expecting 150.00 and True, but will be 100.00 and False.

            // SOLUTION !
            // struct was changed to class because structs are passed by value,
            // which creates a copy when passed to a method.
            // As a result, modifications inside the function do not affect the original currentTx.
            // By changing it to a class, the object is passed by reference,
            // allowing mutations to affect the same instance.


            // Another solution is to use ref to pass the struct by reference instead of by value,
            // avoiding copies and allowing modification of the original variable..

            // ProcessPayment(ref currentTx);
            // static void ProcessPayment(ref BankTransaction tx)


            // Bug #3
            // Program Crashes
            ClassUserProfile guestUser = null;
            PrintReport(guestUser);
        }

        static void ProcessPayment(BankTransaction tx)
        {
            tx.Amount += 50.00m;
            tx.IsVerified = true;
            Console.WriteLine("--- Internal: Payment processed successfully! ---");
        }

        static void PrintReport(ClassUserProfile profile)
        {
            // The case where profile can be null is handled to avoid NullReferenceException.
            // The?. operator prevents accessing UserName if profile is null,
            // and ?? provides default text in that case.
            Console.WriteLine($"USER REPORT: {profile?.UserName.ToUpper() ?? "User Not Found"}");
        }
    }
}