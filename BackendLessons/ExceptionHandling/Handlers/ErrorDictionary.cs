using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Handlers
{
    /*
        Step 1. I'm defining this for avoiding repeating DRY
    */
    internal class ErrorDictionary : Dictionary<int, IErrorHandler>
    {
    }
}
