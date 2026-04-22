namespace Homework1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DOUBLE:");
            double a = 0.1;
            double b = 0.2;
            Console.WriteLine(a + b == 0.3); // Output: False

            // With double uses a binary system, which means that 0.1 is not represented correctly.

            double result = a + b;

            Console.WriteLine($"a = {a.ToString("F20")}");
            Console.WriteLine($"b = {b.ToString("F20")}");
            Console.WriteLine($"a + b = {result.ToString("F20")}");

            Console.WriteLine("DECIMAL:");
            decimal d1 = 0.1m;
            decimal d2 = 0.2m;

            Console.WriteLine(d1 + d2 == 0.3m); // Output: True

            // Decimal uses a decimal system, not binary, which means that 0.1 is represented correctly.

            decimal resultDecimal = d1 + d2;

            Console.WriteLine($"d1 = {d1.ToString("F20")}");
            Console.WriteLine($"d2 = {d2.ToString("F20")}");
            Console.WriteLine($"d1 + d2 = {resultDecimal}");
        }
    }
}
