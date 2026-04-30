using ExceptionHandling.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    internal class Executor
    {
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

                if (Handlers.TryGetValue(ex.GetType(), out IErrorHandler? handler))
                {
                    handler.Handle(context);
                }
            }
        }
    }
}
