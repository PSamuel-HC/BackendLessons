using MyBookHomework.Helpers;
using MyBookHomework.Models;

try
{
    #region PART 1
    Console.WriteLine("My Book:");

    Book myBook = new Book(1, "Juan & Juanita");
    myBook.ShowDetails();

    myBook.Checkout();

    //Verifying changes
    Console.WriteLine("My Book after checkout: ");
    myBook.ShowDetails();

    //Verifying validation:
    //Console.WriteLine("Validation: ");
    //myBook.Checkout();
    #endregion



    #region PART 2

    //1. ARRAY of Genres:
    string[] genres = new string[] { "Comedy", "Action", "Drama"};

    //List of books
    List<Book> books = new List<Book>() { new Book (1, "Juan y Juana"), 
        new Book(1, "Pepito y Juanita"),
        new Book(1, "Pedrito returns"), 
        new Book(1, "Coquito"), };

    //I checked out a book to verify that the Helper works.
    books[0].Checkout();

    //Helper entity:
    MyBookHelper.GetAvailableBooksCount(books);


    #endregion
}

catch (InvalidOperationException ex)
{

    Console.WriteLine(ex.Message);
}
