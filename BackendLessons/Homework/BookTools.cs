using System;
using System.Collections.Generic;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

namespace Homework
{
    public static class BookTools
    {
        public static void BooksCount(List<Book> bookList)
        {
            int availableBooksCount = 0;

            for (int i = 0; i < bookList.Count; ++i)
            {
                availableBooksCount += bookList[i].IsAvailable ? 1 : 0;
            }

            Console.WriteLine($"Number of available books: {availableBooksCount}");

        }
    }
}
