namespace ClassesAndAccessModifiers
{
    public class Book
    {
        public string Title { get; set; }
        private int Id { get; set; }
        private bool IsAvailable { get; set; }

        public Book(string title, int id)
        {
            Title = title;
            Id = id;
            IsAvailable = true;
        }

        public void Checkout()
        {
            IsAvailable = !IsAvailable;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Availability: {IsAvailable}");
        }
    }
}
