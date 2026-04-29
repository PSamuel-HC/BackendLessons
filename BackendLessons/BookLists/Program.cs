using BookClassProgram;
using BookLists.data;
using BookLists.helpers;
using BookLists.models;

namespace BookLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                STEPS
                1. Data structures, you can check it in data/AppData
                2. Helper Entity, check helpers
                3. Program Execution, here
            */

            List<Book> bookList = AppData.Books;

            // UNAVAILABLE BOOKS, remember that books start as available true
            bookList[0].Checkout(false);
            bookList[2].Checkout(false);
            bookList[4].Checkout(false);
            bookList[6].Checkout(false);

            // 3. PROGRAM EXECUTION, here is the main execution, preparing report and printring
            AvailableReport availableReport = CheckAvailability.PrepareAvailableReport(bookList);
            availableReport.PrintReport();
        }
    }
}
