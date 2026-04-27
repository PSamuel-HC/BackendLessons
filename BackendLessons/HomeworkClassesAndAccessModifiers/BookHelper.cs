using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkClassesAndAccessModifiers
{
    public static class BookHelper
    {
        public static void PrintAvailableCount(List<Book> books)
        {
            int count = 0;
            foreach (var book in books)
            {
                if (book.IsAvailable)
                    count++;
            }
            Console.WriteLine($"Total available books: {count} / {books.Count}");
        }
    }
}
