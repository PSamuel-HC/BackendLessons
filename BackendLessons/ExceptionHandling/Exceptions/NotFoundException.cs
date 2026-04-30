using ExceptionHandling.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Exceptions
{
    internal class NotFoundException : BankPlatformException
    {
        public override int ErrorCode => ErrorCodes.NotFound;

        public NotFoundException(string message) : base(message)
        {
        }

    }
}
