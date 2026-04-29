using Jalasoft.GoldenRecord;
using Jalasoft.GoldenRecord.Helpers;
using Jalasoft.GoldenRecord.Models;
using System.Collections;

namespace BackendLessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // * Generics assignment

            User user1 = new User();
            User user2 = new User(Guid.NewGuid(), "Juan");
            User user3 = new User(Guid.NewGuid(), "Jose");

            DataVault<User> userVault = new DataVault<User>();

            userVault.AddItem(user1);
            userVault.AddItem(user2);
            userVault.AddItem(user3);

            User? getUser = userVault.GetById(user2.Id) ?? null;

            // Check it returned corretly
            Console.WriteLine($"Checking returned user is correct: \n" +
                $"user2 name: {user2.Username}\n" +
                $"getUser name: {getUser?.Username}");

        }
    }
}
