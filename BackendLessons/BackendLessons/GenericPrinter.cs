using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.GoldenRecord
{
    public static class GenericPrinter
    {
        public static void Print<T>(T element)
        {
            Console.WriteLine($"{typeof(T).Name} {element}");
        }
    }
}
