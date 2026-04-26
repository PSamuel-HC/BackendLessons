using Homework;


// HOMEWORK - PART 1 
Console.WriteLine("\nHOMEWORK - PART 1 ___________________________________\n");

Book MyFavoriteBook = new Book("Don Quijote", 0);

Console.WriteLine("After being created:");
MyFavoriteBook.ShowDetails();

MyFavoriteBook.Checkout();

Console.WriteLine("\nAfter checkout 1:");
MyFavoriteBook.ShowDetails();

Console.WriteLine($"\nTrying to checkout twice:");
MyFavoriteBook.Checkout();

Console.WriteLine("\nAfter checkout 2:");
MyFavoriteBook.ShowDetails();


// Title can be read from outside:
//Console.WriteLine($"\nReading book title: {MyFavoriteBook.Title}");

// Title cannot be set outsite of the class:
//MyFavoriteBook.Title = "An invalid name"; // This line will throw a compilation error

// The other properties cannot be read or set:
// Console.WriteLine($"\nReading book Id: {MyFavoriteBook.Id}"); // This line will throw a compilation error
// Console.WriteLine($"\nReading book IsAvailable: {MyFavoriteBook.IsAvailable}"); // This line will throw a compilation error
// MyFavoriteBook.Id = 2; // This line will throw a compilation error
// MyFavoriteBook.IsAvailable = true; // This line will throw a compilation error


// HOMEWORK - PART 2
Console.WriteLine("\n\nHOMEWORK - PART 2 ___________________________________\n");

// Array of Genres (Genre is an Enum, but this could be implemented with strings too)
Genre[] GenreArray = {
    Genre.Romance,
    Genre.Crime,
    Genre.Science_Fiction,
    Genre.Travel,
    Genre.Cookbooks,
};

// Print Genre Array Details
Console.WriteLine($"Length of genre array: {GenreArray.Length}");
Console.WriteLine($"Genre Array Items:");
for (int i = 0; i < GenreArray.Length; ++i) Console.WriteLine($"Genre {i+1}: {GenreArray[i]}");

Console.WriteLine("\n-------------------------");


// Books List ----------------------------------------------------------------------------
List<Book> BookList = new List<Book>();
BookList.Add(new Book("The Great Gatsby", 3));
BookList.Add(new Book("1984", 4));
BookList.Add(new Book("The Hobbit", 5));
BookList.Add(new Book("Hamlet", 6));
BookList.Add(new Book("Odyssey", 7));

// Print Books List Details
Console.WriteLine($"\nCount of Books List: {BookList.Count}");
Console.WriteLine($"Books List Items:");
for (int i = 0; i < BookList.Count; ++i)
{
    Console.WriteLine($"Book {i + 1}:");
    BookList[i].ShowDetails();
    Console.WriteLine();
}


Console.WriteLine("-------------------------");


// FIRST TEST: All books should be available
Console.WriteLine("\nAll Books Should be Available:");
BookTools.BooksCount(BookList);


Console.WriteLine("\n-------------------------");


// Perform Random Checkout on each book:
int checkOutCounter = 0;
Random rnd = new Random();
Console.WriteLine("\nPerforming a Some Random Checkouts:");
for (int i = 0; i < BookList.Count; ++i)
{
    if (rnd.Next(2) == 0)
    {
        BookList[i].Checkout();
        Console.WriteLine($"Book {i + 1} has been checked out");
        ++checkOutCounter;
    }
}

// Print How many books have been checked out
Console.WriteLine($"{checkOutCounter} of {BookList.Count} books have been checked out!");

// SECOND TEST: Only some books should be available (Depends on rand)
BookTools.BooksCount(BookList);


Console.WriteLine("\n-------------------------");


// Perform Checkout on the rest of the books
Console.WriteLine("\nChecking Out the rest of the books:");
for (int i = 0;i < BookList.Count; ++i)
{
    if (BookList[i].IsAvailable)
    {
        BookList[i].Checkout();
        Console.WriteLine($"Book {i + 1} has been checked out");
    }
}

// THIRD TEST: Should be 0 available books
BookTools.BooksCount(BookList);


