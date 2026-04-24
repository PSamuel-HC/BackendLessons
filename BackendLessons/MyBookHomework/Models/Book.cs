using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookHomework.Models
{

    sealed class Book //To prevent the class from being inherited, I have set its modifier to "sealed".
    {
        /*Since the id is sensitive, I am not allowing its 
          modification (I have not placed "set") as it should not change*/
        public int Id { get; }

        public string Title { get; set; }

        /*The default book availability is "true", I only allow its
          modification within the class using "private set"*/
        public bool IsAvailable { get; private set; } = true;


        public Book(int _id, string _title)
        {
            Id = _id;
            Title = _title;
        }


        internal void Checkout()
        {
            //I am verifying its availability.
            if (!IsAvailable) throw new InvalidOperationException("Book is not available");
            IsAvailable = false;
        }

        internal void ShowDetails()
        {
            Console.WriteLine($"Book Details:\nTitle: {Title}\nAvailable:: {IsAvailable}");
        }
    }
}
