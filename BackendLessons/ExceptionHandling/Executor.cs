using ExceptionHandling.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    internal class Executor
    {
        // Store the exception handler dictionary for fast lookup
        public Dictionary<Type, IErrorHandler> Handlers { get; set; }

        public Executor(Dictionary<Type, IErrorHandler> handlers)
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
                // Create a context for the caught exception
                ErrorHandlerContext context = new ErrorHandlerContext(ex);

                // Find the handler for this exact exception type
                if (Handlers.TryGetValue(ex.GetType(), out IErrorHandler handler))
                {
                    handler.Handle(context);
                }
            }
        }
    }
}
