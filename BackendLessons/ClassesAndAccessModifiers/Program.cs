namespace ClassesAndAccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name of the book:");
            string bookName = Console.ReadLine() ?? "Book";

            Book book = new Book(bookName, 1);

            Console.WriteLine("Before make the checkout");
            book.ShowDetails();
            book.Checkout();

            Console.WriteLine("\nAfter checkout:");
            book.ShowDetails();
        }
    }
}