using System;
using System.Collections.Generic;
using System.Text;

namespace BookLists.models
{
    internal class AvailableReport
    {
        public int AvailableListCounter { get; set; }
        public string AvailableBookReport { get; set; }
        public string UnavailableBookReport { get; set; }

        public AvailableReport(
            int availableListCounter = 0,
            string availableBookReport = "",
            string unavailableBookReport = ""
        )
        {
            AvailableListCounter = availableListCounter;
            AvailableBookReport = availableBookReport;
            UnavailableBookReport = unavailableBookReport;
        }

        public void PrintReport()
        {
            Console.WriteLine(
                "------------------------------\n" +
                "AVAILABLE REPORT\n" +
                "------------------------------\n" +
                $"Available Books Counter : {AvailableListCounter}\n\n" +
                "* AVAILABLE BOOKS\n" +
                AvailableBookReport + "\n\n"+
                "* UNAVAILABLE BOOKS\n" +
                UnavailableBookReport
            );
        }
    }
}
