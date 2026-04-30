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
                if (ex is BankPlatformException BankPlatformException)
                {
                    ErrorHandlerContext context = new ErrorHandlerContext(ex);
                    IErrorHandler handler = Handlers[BankPlatformException.ErrorCode];

                    handler.Handle(context);
                }
            }
        }
    }
}
