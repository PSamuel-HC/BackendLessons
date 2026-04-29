namespace BookClassProgram
{
    internal class Program
    {
        /*
            Exercise 3:
            a Book is instanced
            the Book is checkouted
            the Book show us its details
        */

        static void Main(string[] args)
        {
            Book myBook = new Book("History of Civilizations", 1);
            myBook.Checkout(false);
            myBook.ShowDetails();
        }
    }
}
