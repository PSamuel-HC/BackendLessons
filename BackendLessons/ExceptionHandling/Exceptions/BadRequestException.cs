using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Exceptions
{
    internal class BadRequestException : BankPlatformException
    {
        public override int ErrorCode => 30;
        public BadRequestException(string message) : base(message)
        {
        }

    }
}
