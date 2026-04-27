using System;

namespace ClassesAndAccessModifiers
{
    // sealed prevents inheritance
    sealed class Book
    {
        public string Title { get; set; }

        // Id can be read outside, but only modified inside the class
        public int Id { get; private set; }

        // IsAvailable can be read outside, but only modified inside the class
        public bool IsAvailable { get; private set; }

        public Book(string title, int id)
        {
            Title = title;
            Id = id;
            IsAvailable = true;
        }

        // Changes the availability state of the book
        public void Checkout()
        {
            IsAvailable = false;
        }

        // Prints the title and current availability to the console
        public void ShowDetails()
        {
            Console.WriteLine($"Book Id: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Available: {IsAvailable}");
        }
    }
}