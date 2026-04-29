using GenericTypesAndConstraints.Models;
using GenericTypesAndConstraints.DataVault;

class Program
{
    static void Main()
    {
        var userVault = new DataVault<User>();

        var user1 = new User(username: "alice");
        var user2 = new User(username: "bob");

        userVault.AddItem(user1);
        userVault.AddItem(user2);

        var found = userVault.GetById(user1.Id);
        Console.WriteLine(found != null ? $"Found user: {found.Username}" : "User not found");

        var notFound = userVault.GetById(Guid.NewGuid());
        Console.WriteLine(notFound == null ? "User not found (as expected)" : "Unexpected user found");

        // Uncomment the following line to see the compile-time error:
        // var intVault = new DataVault<int>();
        // Explanation: int is not a class, does not implement IEntity, and does not have a parameterless constructor, so it fails the constraints.
    }
}
