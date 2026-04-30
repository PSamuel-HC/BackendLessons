using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Exceptions
{
    internal class DuplicateException : BankPlatformException
    {
        public override int ErrorCode => 400;

        public DuplicateException(string message) : base(message)
        {
        }

    }
}
