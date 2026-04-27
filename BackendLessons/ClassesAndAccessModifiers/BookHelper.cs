namespace ClassesAndAccessModifiers
{
    public class BookHelper
    {
        public static void AvailableBooks(List<Book> books)
        {
            int count = 0;
            foreach (var book in books)
            {
                if (book.IsAvailable) count++;
            }

            Console.WriteLine($"The total number of books available is {count}");
        }
    }
}
