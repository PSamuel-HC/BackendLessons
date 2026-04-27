using System;

namespace CollectionsAndHelpers.Classes
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
}