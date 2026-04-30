using Homework_ExceptionHandling.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling.Exceptions
{
    internal class NotFoundException : BankPlatformException
    {
        public override BankErrorCode ErrorCode => BankErrorCode.NotFound;


        public NotFoundException(string message) : base(message)
        {
        }

    }
}
