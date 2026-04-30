using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_ExceptionHandling.Enums
{
    // Using ushort to optimize memory usage from 32 to 16 bits
    internal enum BankErrorCode : ushort
    {
        Unknown = 0,
        BadRequest = 400,
        NotFound = 404,
        Duplicate = 409,
    }
}
