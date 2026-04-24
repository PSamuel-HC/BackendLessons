using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkClassses
{
    sealed class BookClass
    {

        //the 3 Properties
        public string Title { get; set; }
        // private to protect it 
        private int Id { get; set; }
        // private to protect it 
        private Boolean IsAvailable { get; set; }

        // constructor that receives two arguments and set availability automatically
        public BookClass(string title, int id) {
            Title = title;
            Id = id;
            IsAvailable = true;
        }

        // first method requested
        public void Checkout() {
            if (IsAvailable)
            {
                IsAvailable = false;
            }
            else
            {
                Console.WriteLine("Book is already not available");
            }
        }

        // I decided to add this extra method because it made sence jaja
        public void CheckIn()
        {
            if (IsAvailable)
            {
                 Console.WriteLine("Book is already available");
            }
            else
            {
                IsAvailable = true;
            }
        }

        //second method requested
        public void ShowDetails()
        {
            Console.WriteLine("Title: " + Title + ", Is this book available? " + IsAvailable);
        }
    }
}
