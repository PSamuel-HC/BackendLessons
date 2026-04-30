using ExceptionHandling.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    internal class Executor
    {
        // Changing list for dictionary
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
                ErrorHandlerContext context = new ErrorHandlerContext(ex);

                // Accesing directly the handler
                IErrorHandler handler = Handlers[context.CustomException.GetType()];

                // Executing Handle method of the needed handler
                handler.Handle(context);

            }
        }
    }
}
