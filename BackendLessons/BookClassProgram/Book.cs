using System;
using System.Collections.Generic;
using System.Text;

namespace BookClassProgram
{
    /*
        Exercise 1: Other Objects shouldn't be able to inherit nothing fron this class
        this is the reason that we use SEALED here
    */
    internal sealed class Book
    {
        /*
            Exercise 1:
            Properties id, title and isAvailable
            id and isAvailable are protected by "private"
            
        */
        private int _Id;
        public string Title { get; set; }
        private bool _IsAvailable;

        /*
            Exercise 1:
            Constructor: Initiaalize with Title and Id
            Is Available is always true
        */
        public Book(string title, int id)
        {
            _Id = id;
            Title = title;
            _IsAvailable = true;
        }

        /*
            Exercise 2:
            Checkout changes visibility
        */
        public void Checkout(bool isAvailable)
        {
            _IsAvailable = isAvailable;
        }

        /*
            Exercise 2:
            Prints information of the book
        */
        public void ShowDetails()
        {
            Console.WriteLine("BOOK INFORMATION\n" +
                "----------\n" +
                $"Book: {Title}\n" +
                $"Available: {(_IsAvailable ? "Yes": "No")}\n\n\n");
        }

    }
}
