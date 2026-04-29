using Homework_GenericTypesAndConstraints.Data;
using Homework_GenericTypesAndConstraints.Models;

namespace Homework_GenericTypesAndConstraints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 - Instantiate DataVault<User>
            DataVault<User> userVault = new DataVault<User>();

            // 2 - Add users (Using different constructors)
            User user1 = new User { Username = "Luigi" };
            User user2 = new User(null, "Samuel");

            userVault.AddItem(user1);
            userVault.AddItem(user2);

            // 3 - Test CreateAndAdd
            User user3 = userVault.CreateAndAdd();
            user3.Username = "Bot 123"; // Set a name for print 

            // 4 - Test GetById
            User? foundUser1 = userVault.GetById(user1.Id);
            Console.WriteLine($"Found User 1: '{(foundUser1 == null ? "null" : foundUser1.Username)}'");

            // 5 - Test GetById (Not found)
            User? foundUser2 = userVault.GetById(Guid.NewGuid());
            Console.WriteLine($"Found User 2: '{(foundUser2 == null ? "null" : foundUser2.Username)}'");

            // 6 - Test GetById
            User? foundUser3 = userVault.GetById(user3.Id);
            Console.WriteLine($"Found User 3: '{(foundUser3 == null ? "null" : foundUser3.Username)}'");

            // 7 - Try DataVault<int> (This will throw a compilation error)
            // DataVault<int> intVault = new DataVault<int>();
            // This fails because int is a value type and the DataVault class has a constraint to
            // only accept reference datatypes as templates. Also, int does not implement IEntity
            // which is another constraint that DataVault has.

        }
    }
}
