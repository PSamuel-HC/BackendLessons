using HomeworkClassesAndAccessModifiers;
using static System.Net.WebRequestMethods;

Console.WriteLine("---------Testing Checkout funtionality:---------");
Book book1 = new Book("The Title",123);

Console.WriteLine("Before Chekout:");
book1.ShowDetails();
Console.WriteLine("\n");
book1.Checkout();
Console.WriteLine("After Chekout: ");
book1.ShowDetails();


Console.WriteLine("---------Testing genres and helper entity funtionality:---------");
string[] genres = { "Sci-Fi", "Action", "Drama" };

List<Book> books = new List<Book>
{
    new Book("Dune",              1),
    new Book("The Dark Knight",   2),
    new Book("The Godfather",     3),
    new Book("Foundation",        4),
    new Book("Pride and Prejudice", 5)
};

Console.WriteLine("Genres Available:");
foreach (var genre in genres)
    Console.WriteLine($"  - {genre}");

Console.WriteLine("\nBook List:");
foreach (var book in books) { 
    book.ShowDetails();
}

Console.WriteLine();
BookHelper.PrintAvailableCount(books);   // All 5 should be available

// ── 3. PROGRAM EXECUTION — simulate some checkouts ───────────────
Console.WriteLine("\n=== Checking out 'Dune' and 'Foundation' ===");
books[0].Checkout();   // Dune → not available
books[3].Checkout();   // Foundation → not available

Console.WriteLine("\n=== Updated Book List ===");
foreach (var book in books)
    book.ShowDetails();

Console.WriteLine();
BookHelper.PrintAvailableCount(books);