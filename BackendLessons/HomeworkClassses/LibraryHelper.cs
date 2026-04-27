using HomeworkClassses;
using System;
using System.Collections.Generic;
using System.Text;

class LibraryHelper
{
    public static int CountAvailableBooks(List<BookClass> books)
    {
        int count = 0;
        foreach (BookClass book in books)
        {
            if (book.CheckAvailability())
            {
                count++;
            }
        }
        return count;
    }

    public static void PrintAvailableBooks(List<BookClass> books)
    {
        int available = CountAvailableBooks(books);
        Console.WriteLine("Total available books:" + available);
    }
}