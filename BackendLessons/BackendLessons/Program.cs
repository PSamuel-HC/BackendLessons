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
            User user1 = new User();
            User user2 = new User(Guid.NewGuid(), "Juan");
            User user3 = new User(Guid.NewGuid(), "Jose");

            DataVault<User> userVault = new DataVault<User>();

            userVault.AddItem(user1);
            userVault.AddItem(user2);
            userVault.AddItem(user3);


            // * TEST CODE - IGNORE

            //Product product1 = new Product { };
            //Product product2 = new Product { };

            //Console.WriteLine($"This is user1 guid: {user1.Id}\n" +
            //    $"and this is product1 guid: {product1.Id}");

            //Console.WriteLine($"This is user2 guid: {user2.Id}\n" +
            //    $"and user2 name: {user2.Username}");

            //Console.WriteLine($"This is product1 price: {product1.Price}");

        }
    }
}
