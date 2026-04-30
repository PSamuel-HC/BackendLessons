using ExceptionHandling.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    internal class Executor
    {
        public List<IErrorHandler> Handlers { get; set; }

        public Executor(List<IErrorHandler> handlers)
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

                foreach (IErrorHandler handler in Handlers) 
                {
                    handler.Handle(context);

                    //cuando paramos?
                    if (context.Handled) break;

                }
            }
        }
    }
}
