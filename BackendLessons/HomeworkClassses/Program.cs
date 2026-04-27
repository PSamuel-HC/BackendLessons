using HomeworkClassses;

internal class Program
{
    static void Main(string[] args)
    {
        //Create a List of Books
        List<BookClass> Library = new List<BookClass>();
        //Creating books but saving them with a variable name so I can access them
        BookClass book1 = new BookClass("100 años de soledad", 1, new string[] {"fiction", "fantasy"});
        BookClass book2 = new BookClass("Libro 2", 2, new string[] {"fiction", "fantasy", "suspense"});
        BookClass book3 = new BookClass("´Libro sin nombre", 3, new string[] {"Comedy"});

        //adding books to the list
        Library.Add(book1);
        Library.Add(book2);
        Library.Add(book3);
        //showed first book details
        book1.ShowDetails();
        //show list with helper method of available books
        LibraryHelper.PrintAvailableBooks(Library);

        //confirmed checkout alert
        book1.Checkout();
        book1.Checkout();

        //confirmed checkin alert
        book1.CheckIn();
        book1.CheckIn();

        //final checkout
        LibraryHelper.PrintAvailableBooks(Library);
        book1.Checkout();


        //display the details to verify the logic
        book1.ShowDetails();
        LibraryHelper.PrintAvailableBooks(Library);

    }

}