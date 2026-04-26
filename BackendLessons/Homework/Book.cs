using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    // Using sealed in order to avoid other class to inherit from this class
    public sealed class Book
    {

        // Title property can only be modified by the class itself but can be read from outsite.
        // Id and IsAvailable are sensitive, so only the class can read and update these properties.

        public string Title { get; private set; }
        private int Id { get; set; }
        public bool IsAvailable { get; private set; } // We had to change this in order to access availability

        public Book (string title, int id)
        {
            Title = title;
            Id = id;
            IsAvailable = true;
        }


        public void Checkout()
        {
            if (!IsAvailable)
            {
                Console.WriteLine($"Book is already not available");
                return;
            }
            IsAvailable = false;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Title: {Title}\nAvailable: {IsAvailable}");
        }

    }
}
