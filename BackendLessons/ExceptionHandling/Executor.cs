using ExceptionHandling.Exceptions;
using ExceptionHandling.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    internal class Executor
    {
        public Dictionary<int, IErrorHandler> Handlers { get; set; } 

        public Executor(Dictionary<int, IErrorHandler> handlers)
        {
            Handlers = handlers;
        }
        
        public void Execute(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch(Exception ex)
            {
                ErrorHandlerContext context = new ErrorHandlerContext(ex);

                if (ex is BankPlatformException bankExc && Handlers.ContainsKey(bankExc.ErrorCode))
                {
                    Handlers[bankExc.ErrorCode].Handle(context);
                }
                else
                {
                    Console.WriteLine("Executor: Unable to handle unknown exception");
                    Console.WriteLine($"Executor: {ex}");

                }
            }
        }
    }
}
