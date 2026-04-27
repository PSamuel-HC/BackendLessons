namespace ClassesAndAccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            string[] genres = { "Sci-Fi", "Action", "Drama" };
            List<Book> books = new List<Book>();
            int nextBookId = 0;

            while (running)
            {
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Checkout Book");
                Console.WriteLine("3. List Available Books");
                Console.WriteLine("4. See genres");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Name of the book:");
                        string bookName = Console.ReadLine() ?? "Book";

                        Book book = new Book(bookName, nextBookId++);
                        books.Add(book);
                        Console.WriteLine("Book added\n");
                        break;

                    case "2":
                        Console.WriteLine("Enter book ID:");

                        try
                        {
                            int id = int.Parse(Console.ReadLine() ?? "");
                            Book? bookFound = books.Find(b => b.Id == id);

                            if (bookFound == null)
                            {
                                Console.WriteLine("Book not found");
                                return;
                            }
                            Console.WriteLine("Before make the checkout");
                            bookFound.ShowDetails();
                            bookFound.Checkout();

                            Console.WriteLine("\nAfter checkout:");
                            bookFound.ShowDetails();;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid ID");
                        }
                        break;
                    case "3":
                        BookHelper.AvailableBooks(books);
                        break;
                    case "4":
                        foreach (var genre in genres) Console.WriteLine($"* {genre}");
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}