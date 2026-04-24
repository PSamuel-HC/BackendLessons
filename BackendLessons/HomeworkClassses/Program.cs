using HomeworkClassses;

internal class Program
{
    static void Main(string[] args)
    {
        //book instantiatedin the main program
        BookClass book = new BookClass("100 años de soledad", 1);
        //showed first book details
        book.ShowDetails();

        //confirmed checkout alert
        book.Checkout();
        book.Checkout();

        //confirmed checkin alert
        book.CheckIn();
        book.CheckIn();

        //final checkout
        book.Checkout();

        //display the details to verify the logic
        book.ShowDetails();
        
    }

}