using Homework_ExceptionHandling.Enums;
using Homework_ExceptionHandling.Exceptions;
using Homework_ExceptionHandling.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_ExceptionHandling
{
    internal class Executor
    {

        // Create a dictionary that maps error codes to Handlers
        public Dictionary<BankErrorCode, IErrorHandler> Handlers { set; get; }

        public Executor(Dictionary<BankErrorCode, IErrorHandler> handlers)
        {
            Handlers = handlers;
        }

        public void Execute(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                ErrorHandlerContext context = new ErrorHandlerContext(ex);

                // Check if the error is a BankPlatformException and creates a new casted var bankExc 
                // (This is done in order to use bankExc.ErrorCode)
                // If Exception is not a BankPlatformException or Error code is not mapped to an error handler:
                // print error and tell that we wer not able to solve it 
                if (ex is BankPlatformException bankExc && Handlers.ContainsKey(bankExc.ErrorCode))
                {
                    Handlers[bankExc.ErrorCode].Handle(context);
                }
                else
                {
                    Console.WriteLine("Executor: Unable to handle unknown exception");
                    Console.WriteLine($"Executor: {ex.ToString()}");
                }

            }
        }
    }
}
