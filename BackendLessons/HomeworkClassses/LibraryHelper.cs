using HomeworkClassses;
using System;
using System.Collections.Generic;
using System.Text;

//We create a new class so we can follow SINGLE RESPONSABILITY Principle
class LibraryHelper
{
    //We create the static method because its a helper and it receives a lists of books objects
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

    // We create the actual helper to print the available books
    public static void PrintAvailableBooks(List<BookClass> books)
    {
        int available = CountAvailableBooks(books);
        Console.WriteLine("Total available books:" + available);
    }
}