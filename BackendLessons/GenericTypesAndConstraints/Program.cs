using GenericTypesAndConstraints.Models;

namespace GenericTypesAndConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            DataVault<User> userResponse = new DataVault<User>();

            while (running)
            {
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Get User");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter the Name:");
                        string username = Console.ReadLine() ?? "Edson";
                        Guid newId = Guid.NewGuid();
                        User newItem = new User(newId, username);
                        userResponse.AddItem(newItem);

                        Console.WriteLine("User added\n");
                        break;

                    case "2":
                        Console.WriteLine("Enter user ID:");
                        try
                        {
                            Guid id = Guid.Parse(Console.ReadLine() ?? "");
                            User userFound = userResponse.GetById(id);
                            if (userFound != null)
                            {
                                Console.WriteLine($"The user found is {userFound.Username}");
                            }
                            else
                            {
                                Console.WriteLine("User not found");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid ID");
                        }
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }

            // This fails because the int does not meet the constraints we set.
            // int is a value type (struct) not a reference type.
            // It also does not implement IEntity.
            // DataVault<int> test = new DataVault<int>();
        }
    }
}