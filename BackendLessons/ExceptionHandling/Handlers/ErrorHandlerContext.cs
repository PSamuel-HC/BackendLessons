using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Handlers
{
    internal class ErrorHandlerContext
    {
        public Exception CustomException { get; }
        // STEP 3 ADD List of messages
        public List<string> messageList { get; set; } = [];

        public bool Handled { get; set; }

        // Add Message
        public void AddFailedMessage()
        {
            messageList.Add($"Request Nº{messageList.Count + 1} has failed");
        }
        public void ShowMessages()
        {
            foreach (string message in messageList)
            {
                Console.WriteLine(message);
            }
        }

        public ErrorHandlerContext(Exception exception)
        {
            CustomException = exception;
        }
    }
}
