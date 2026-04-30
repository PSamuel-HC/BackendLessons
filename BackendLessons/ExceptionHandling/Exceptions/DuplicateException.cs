using ExceptionHandling.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Exceptions
{
    internal class DuplicateException : BankPlatformException
    {
        public override short ErrorCode => ErrorCodes.DuplicateError; //I am using "constants" declared in the static errors class

        public DuplicateException(string message) : base(message)
        {
        }
        public DuplicateException(string message, List<string> messages) : base(message, messages)
        {

        }
        //I overloaded the class constructors to match its parent.
    }
}
