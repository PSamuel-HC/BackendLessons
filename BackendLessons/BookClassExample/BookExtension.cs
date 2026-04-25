class BookExtension
{
    // Helper to count books
    public static void CountAvailableBooks(List<Book> books)
    {
        if (books.Count() == 0)
        {
            Console.WriteLine("The books list is empty");
            return;
        }

        int count = 0;

        foreach (Book book in books)
        {
            if (book.IsAvailable)
            {
                count++;
            }
        }

        Console.WriteLine($"There are {count} books available");
    }

}