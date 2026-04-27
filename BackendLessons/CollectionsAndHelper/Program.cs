using System;
using System.Collections.Generic;

namespace CollectionsAndHelpers
{
    class Book
    {
        public string Title { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, bool isAvailable)
        {
            Title = title;
            IsAvailable = isAvailable;
        }
    }

    class BookHelper
    {
        public static int CountAvailableBooks(List<Book> books)
        {
            int count = 0;

            foreach (Book book in books)
            {
                if (book.IsAvailable)
                {
                    count++;
                }
            }

            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Data Structures ===\n");
            // Output: shows the section where genres are displayed

            string[] genres = { "Sci-Fi", "Action", "Drama" };

            Console.WriteLine("Genres:");
            // Output: prints the list of genres

            foreach (string genre in genres)
            {
                Console.WriteLine($"- {genre}");
            }

            Console.WriteLine("\n=== Books ===\n");
            // Output: shows the section where book data is displayed

            List<Book> books = new List<Book>
            {
                new Book("Dune", true),
                new Book("John Wick", false),
                new Book("The Godfather", true)
            };

            foreach (Book book in books)
            {
                Console.WriteLine($"Title: {book.Title} | Available: {book.IsAvailable}");
                // Output: prints each book with its availability
            }

            Console.WriteLine("\n=== Helper Result ===\n");
            // Output: shows helper result section

            int availableBooks = BookHelper.CountAvailableBooks(books);

            Console.WriteLine($"Total available books: {availableBooks}");
            // Output: prints total available books
        }
    }
}