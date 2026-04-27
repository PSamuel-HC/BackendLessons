using BookLists.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClassProgram
{
    /*
        I re-used the previous class, but I added Genre Attribute.
        I changed isavailable to public
    */
    internal sealed class Book
    {
        private int _Id;
        public string Title { get; set; }
        public BookGenre Genre { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, int id, BookGenre genre)
        {
            _Id = id;
            Title = title;
            Genre = genre;
            IsAvailable = true;
        }

        public void Checkout(bool isAvailable)
        {
            IsAvailable = isAvailable;
        }

        public void ShowDetails()
        {
            Console.WriteLine("BOOK INFORMATION\n" +
                "----------\n" +
                $"Book: {Title}\n" +
                $"Available: {(IsAvailable ? "Yes" : "No")}\n\n\n");
        }

    }
}
