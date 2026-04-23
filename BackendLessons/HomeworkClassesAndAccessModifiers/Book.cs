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
        private bool _isAvilable;

        public Book (string title, int id)
        {
            Title = title;
            _id = id;
            _isAvilable = true;
        }
        public void Checkout() {
            _isAvilable = !_isAvilable;
        }
        public void ShowDetails() {
            Console.WriteLine($"Title:{Title}");
            Console.WriteLine($"Available:{_isAvilable}");
        }
    }
}