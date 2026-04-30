using ExceptionHandling.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Exceptions
{
    internal class NotFoundException : BankPlatformException
    {
        public override short ErrorCode => ErrorCodes.NotFoundError;


        public NotFoundException(string message) : base(message)
        {
        }
        public NotFoundException(string message, List<string> messages ) : base(message, messages)
        {
        }
        //I overloaded the constructors
    }
}
