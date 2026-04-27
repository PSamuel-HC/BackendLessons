using BookClassProgram;
using BookLists.models;

namespace BookLists.helpers
{
    internal static class CheckAvailability
    {
        // 2. HELPER ENTITY
        public static AvailableReport PrepareAvailableReport(List<Book> list)
        {
            // CREATING REPORT
            AvailableReport report = new AvailableReport();

            list.ForEach((book) =>
            {
                // CHECK IF BOOK IS AVAILABLE AND SAVE TEXT
                if (book.IsAvailable)
                {
                    report.AvailableBookReport = AddBookInReport(report.AvailableBookReport, book);
                    report.AvailableListCounter++;
                }
                else
                {
                    report.UnavailableBookReport = AddBookInReport(report.UnavailableBookReport, book);
                }
            });

            // RETURN REPORT
            return report;
        }

        private static string AddBookInReport(string text, Book book)
        {
            return $"{text + book.Title} : {book.Genre}\n";
        }

    }
}
