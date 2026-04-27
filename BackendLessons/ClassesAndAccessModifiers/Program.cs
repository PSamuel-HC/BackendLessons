using System;

namespace ClassesAndAccessModifiers
{
    sealed class Book
    // sealed prevents inheritance
    {
        public string Title { get; set; }
        public int Id { get; private set; }
        
        public bool IsAvailable { get; private set; }
        // protected with private set: you can read the values, but only the class can modify them
        public Book(string title, int id)
        {
            Title = title;
            Id = id;
            IsAvailable = true;
        }
        //Changes the availability state of the book
        public void Checkout()
        {
            IsAvailable = false;
        }

        //prints the title and current availability to the console
        public void showDetails()
        {
            Console.WriteLine($"Book Id: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Available: {IsAvailable}");
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the book class in your main program, perform a checkout, 
            // and display the details to verify the logic
            Book book = new Book("C# Basics",1);
            Console.WriteLine("Before checkout");
            book.showDetails();

            Console.WriteLine();

            book.Checkout();

            Console.WriteLine("After checkout:");
            book.showDetails();
        }
    }
}
