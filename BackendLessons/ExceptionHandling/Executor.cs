using ExceptionHandling.Exceptions;
using ExceptionHandling.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    internal class Executor
    {
        // STEP 1
        /*
            I change List of Dictionary 
        */
        public ErrorDictionary Handlers { get; set; }

        public Executor(ErrorDictionary handlers)
        {
            Handlers = handlers;
        }

        public void Execute(Action action)
        {
            try
            {
                action.Invoke();
            }
            // I changed BankPlataform for using ErrorCode
            catch (BankPlatformException ex)
            {
                ErrorHandlerContext context = new(ex);
                // STEP 1
                /*
                    I replaced for structure with TryGetValue
                    that Dictionaries use, Message of Expection
                    and I compared with the dictionary of my handlers
                */
                int errorCode = ex.ErrorCode;
                if (Handlers.TryGetValue(errorCode, out IErrorHandler? handler))
                {
                    handler.Handle(context);
                }
            }
        }
    }
}
