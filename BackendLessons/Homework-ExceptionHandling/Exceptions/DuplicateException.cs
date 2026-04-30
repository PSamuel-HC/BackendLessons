using Homework_ExceptionHandling.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_ExceptionHandling.Exceptions
{

    internal class DuplicateException : BankPlatformException
    {
        public override BankErrorCode ErrorCode => BankErrorCode.Duplicate;

        public DuplicateException(string message) : base(message)
        {

        }
    }
}
