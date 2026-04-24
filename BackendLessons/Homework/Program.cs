using Homework;

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