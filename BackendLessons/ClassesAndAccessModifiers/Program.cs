using System;

namespace ClassesAndAccessModifiers
{
    sealed class Book
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, int id)
        {
            Title = title;
            Id = id;
            IsAvailable = true;
        }

        public void Checkout()
        {
            IsAvailable = false;
        }

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
