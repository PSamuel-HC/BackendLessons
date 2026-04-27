using System;
using System.Collections.Generic;
using CollectionsAndHelpers.Classes;
using CollectionsAndHelpers.Helpers;

namespace CollectionsAndHelpers
{
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