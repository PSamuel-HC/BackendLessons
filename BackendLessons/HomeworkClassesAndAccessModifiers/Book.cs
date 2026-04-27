using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace HomeworkClassesAndAccessModifiers
{
    public sealed class Book
    {
        public string Title { get;}
        private int _id;
        private bool _isAvailable;

        public Book (string title, int id)
        {
            Title = title;
            _id = id;
            _isAvailable = true;
        }

        public bool IsAvailable => _isAvailable;

        public void Checkout() {
            _isAvailable = !_isAvailable;
        }
        public void ShowDetails() {
            Console.WriteLine($"Title:{Title}");
            Console.WriteLine($"Available:{_isAvailable}");
        }
    }
}