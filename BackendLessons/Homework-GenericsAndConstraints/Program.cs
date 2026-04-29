
using JalaUniversity.Homework_GenericsAndConstraints.Models;
using JalaUniversity.Homework_GenericsAndConstraints.Repositories;

User u1= new User(), u2 = new User(), u3 = new User();

User u4 = new User(Guid.NewGuid(), "Juanita");

DataVault<User> dataVault = new DataVault<User>();

Console.WriteLine("Adding Users: ");

dataVault.AddItem(u1);
dataVault.AddItem(u2);
dataVault.AddItem(u3);
dataVault.AddItem(u4);

Console.WriteLine("\nGetting User 1 with id: "+u1.Id);
User? userResult = dataVault.GetById(u1.Id);
Console.WriteLine("User Id: "+ (userResult?.Id.ToString() ?? "User was not found"));
 
Console.WriteLine("\nGetting User that doesn't exist");
User? userResult2 = dataVault.GetById(Guid.NewGuid());
Console.WriteLine("User Id: " + (userResult2?.Id.ToString() ?? "User was not found"));

Console.WriteLine("\nCreating and Adidng new User");
dataVault.CreateAndAdd();


//DATAVAULT INT: 
//DataVault<int> myData = new DataVault<int>();

/*
 The "int" data type is not allowed because it does not meet any of the restrictions we set.
 It is a value type. Furthermore, it does not implement our interface.
 */

