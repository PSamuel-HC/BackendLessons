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
            UserProfile primaryUser = new UserProfile { UserName = "Alice", Rank = "Gold" };
            UserProfile backupUser = primaryUser; // BUG: Reference Copy

            backupUser.UserName = "Bob";

            Console.WriteLine("First Solution: ");
            Console.WriteLine($"Primary User: {primaryUser.UserName}");
            // Bug #1
            // Expecting "Alice", but it will be "Bob".

            /*
             * SOLUTION 1: 
             * To correct this error, given the expected result, the reference data type "class" was
             * changed to a value data type "struct".
             * This way, the information is stored on the stack, and when assigning the data to the second variable ("backupUser"),
             * a copy of the information is passed instead of a reference.
             */



            BankTransaction currentTx = new BankTransaction { Amount = 100.00m, IsVerified = false };

            ProcessPayment(currentTx);
            Console.WriteLine("\nSecond Solution: ");
            Console.WriteLine($"Final Balance: {currentTx.Amount}, Verified: {currentTx.IsVerified}");
            // Bug #2
            // Expecting 150.00 and True, but will be 100.00 and False.

            /*
              * SOLUTION 2: 
              * Similarly, given the expected outcome in this situation, the best alternative is
              * to change the data type from `struct` to a reference type, such as `class`.
              * This way, when passed the reference variable 
              * as an argument to the method, it will correctly perform all the required changes.
              */



            // Bug #3
            // Program Crashes

            /*
           * SOLUTION 3: 
           * First, since we want to assign a null value to the variable, we must make 
           * it accept null values ​​using the "?" symbol. 
           * Then, the function must also receive a parameter that accepts null values.
           */

            UserProfile? guestUser = null;
            Console.WriteLine("\nThird Solution: ");
            PrintReport(guestUser);
        }

        static void ProcessPayment(BankTransaction tx)
        {
            tx.Amount += 50.00m;
            tx.IsVerified = true;
            Console.WriteLine("--- Internal: Payment processed successfully! ---");
        }

        static void PrintReport(UserProfile? profile)
        {
            if (profile == null) { Console.WriteLine("User Profile doesn't exists or it is a guest"); return; }
            /*The userprofile can be "Null", so we must
             * perform additional validations. This can be done using
             * standard conditional statements, the "null-coalescing operator",
             * or some other method.
             * */

            Console.WriteLine($"USER REPORT: {profile?.UserName.ToUpper()}");

            // we could also do the follworing ("if" is not going to be necessary):
            //Console.WriteLine($"USER REPORT: {(profile?.UserName.ToUpper() ?? "UNKNOWN")}");
        }
    }
}