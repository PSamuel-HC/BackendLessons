using HomeworkClassesAndAccessModifiers;
using static System.Net.WebRequestMethods;

Book book = new Book("The Title",123);

Console.WriteLine("Before Chekout:");
book.ShowDetails();
Console.WriteLine("\n");
book.Checkout();
Console.WriteLine("After Chekout: ");
book.ShowDetails();