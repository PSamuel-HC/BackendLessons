using ExceptionHandling.Exceptions;
using ExceptionHandling.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    internal class Executor
    {
        public Dictionary<short, IErrorHandler> Handlers { get; set; } //I'm using the "error code" as the key

        public Executor(Dictionary<short, IErrorHandler> handlers)
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
                if(ex is BankPlatformException bankEx) //It is being validated that the exception is a child class of Bankplatformexc.
                {
                    if (Handlers.ContainsKey(bankEx.ErrorCode))
                    {
                        ErrorHandlerContext context = new ErrorHandlerContext(ex, bankEx.Messages); //Here, the exception errors are being passed to the context.
                        Handlers[bankEx.ErrorCode].Handle(context);
                    }
                }
               
            }
        }
    }
}
