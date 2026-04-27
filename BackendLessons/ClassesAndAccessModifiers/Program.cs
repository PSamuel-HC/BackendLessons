using System;

namespace ClassesAndAccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the Book class, perform a checkout,
            // and display the details to verify the logic
            Book book = new Book("C# Basics", 1);

            Console.WriteLine("Before checkout:");
            book.ShowDetails();

            Console.WriteLine();

            book.Checkout();

            Console.WriteLine("After checkout:");
            book.ShowDetails();
        }
    }
}