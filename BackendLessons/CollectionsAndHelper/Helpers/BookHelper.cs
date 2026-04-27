using System.Collections.Generic;
using CollectionsAndHelpers.Classes;

namespace CollectionsAndHelpers.Helpers
{
    class BookHelper
    {
        public static int CountAvailableBooks(List<Book> books)
        {
            int count = 0;

            foreach (Book book in books)
            {
                if (book.IsAvailable)
                {
                    count++;
                }
            }

            return count;
        }
    }
}