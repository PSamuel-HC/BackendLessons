using MyBookHomework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookHomework.Helpers
{
    internal static class MyBookHelper
    {
        /*
         I decided to make the class static in order to avoid instantiating it every
         time its functionality is needed. Furthermore, since it's a helper class,
          the behavior of a non-static class is not usually necessary.
         */
        public static void GetAvailableBooksCount(List<Book> books)
        {
            int availableBooksCount = books.Where(x => x.IsAvailable).Count();
            Console.WriteLine("Total available Books: " + availableBooksCount);
        }
        /*
         Furthermore, I decided to keep this simple, given the nature of the task.
         And, for better readability, I decided to use a WHERE clause to filter
         the available books.
         */

    }
}
