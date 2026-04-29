using System.Security.Cryptography;

namespace ClassesAndAccessModifiers
{
    sealed class Book
    {
        public string Title { get; set; }
        private int _Id { get; set; }
        private bool _IsAvailable { get; set; }

        public Book(string title, int id)
        {
            Title = title;
            _Id = id;
            _IsAvailable = true;
        }

        public void Checkout()
        {
            _IsAvailable = !_IsAvailable;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Availability: {_IsAvailable}");
        }

        public bool IsAvailable => _IsAvailable;
        public int Id => _Id;
    }
}
