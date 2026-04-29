using homework_05.Models;

namespace homework_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TASK 3
            /*
                Instantiate DataVault with User
            */
            DataVault<User> userVault = new();

            /*
                Add Users
            */
            userVault.AddItem(new User { Id = 1, Username = "Maria" });
            userVault.AddItem(new User { Id = 2, Username = "Adrian" });
            userVault.AddItem(new User { Id = 3, Username = "Aaron" });

            /*
                Get by Id 
            */
            User foundUser = userVault.GetById(1);
            Console.WriteLine(foundUser != null ? $"Found: {foundUser.Username}" : "Not found");


            /*
                new DataVault<int>()
                
                It fails because T as class, IEntity, new();
                For using int, string or other Stack Values we need to use
                struct instead of class
            */
            // DataVault<int> intVault = new();
        }
    }
}
