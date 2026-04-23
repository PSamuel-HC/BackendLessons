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

            

            Console.WriteLine($"Primary User: {primaryUser.UserName}");
            // Bug #1
            // Expecting "Alice", but it will be "Bob".
            // Since its a reference copy, both are aiming at the same object saved on the heap, so even if you changed backupUser, you changed the object on the heap.
            // same primaryUser was referring to.


            BankTransaction currentTx = new BankTransaction { Amount = 100.00m, IsVerified = false };

            currentTx = ProcessPayment(currentTx);

            Console.WriteLine($"Final Balance: {currentTx.Amount}, Verified: {currentTx.IsVerified}");
            // Bug #2
            // Expecting 150.00 and True, but will be 100.00 and False.

            // IN this case, we were just sending a copy of the original reference
            // So in this case, we have two options:
            // 1. pass the object with ref and receive it with ref in the method
            // 2. return the object modified in the method and assign its value to the original reference.


            // Bug #3
            // Program Crashes
            // And here to finish we have again, two options:
            // 1. Modify the method to be able to handle a null object like I did
            // 2. the easy fix, just don't send a null object and it will work just fine.
            UserProfile guestUser = null;
            PrintReport(guestUser);
        }

        static BankTransaction ProcessPayment(BankTransaction tx)
        {
            tx.Amount += 50.00m;
            tx.IsVerified = true;
            Console.WriteLine("--- Internal: Payment processed successfully! ---");
            return tx;
        }

        static void PrintReport(UserProfile? profile)
        {
            if(profile == null)
            {
                Console.WriteLine("user not found!");
                return;
            }

            Console.WriteLine($"USER REPORT: {profile.UserName.ToUpper()}");
        }
    }
}