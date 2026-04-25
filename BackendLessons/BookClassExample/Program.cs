using System;

// Run using command on terminal 'dotnet run'
public class Program
{
	static void Main()
	{
		// --- CLASSES ASSIGNMENT ---

		Book harryPotter = new Book("Harry Potter and the Philosopger's stone", 1);
		// Checking isAvailable is true at first
		harryPotter.ShowDetails();
		// Change it
		harryPotter.Checkout();
		// Checking is now false
		Console.WriteLine('\n');
        harryPotter.ShowDetails();

        // --- ARRAYS AND LISTS ASSIGNMET ---

        // Array of genres
        string[] bookGenres = { "Sci-fi", "Fantasy", "Drama", "Biography", "Action" };

		// List of books
		List<Book> books = new List<Book> { harryPotter };
		books.Add(new Book("Harry Potter and the Chamber of Secrets", 2));
		books.Add(new Book("Harry Potter and the Prisoner of Azkaban", 3));
		books.Add(new Book("Harry Potter and the Goblet of Fire", 4));
		books.Add(new Book("Harry Potter and the Order of the Phoenix", 5));
		books.Add(new Book("Harry Potter and the Half-Blood Prince", 6));
		books.Add(new Book("Harry Potter and the Deathly Hallows", 7));

		Console.WriteLine('\n');
        BookExtension.CountAvailableBooks(books);

    }
}
