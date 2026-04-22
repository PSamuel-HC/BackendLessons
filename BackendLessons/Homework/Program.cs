namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Double example ---
            double a = 0.1;
            double b = 0.2;
            double sumDouble = a + b;

            Console.WriteLine($"Here we are adding a + b, where a = {a} and b = {b}");
            Console.WriteLine($"The result of a + b is {sumDouble}, which is different from 0.3");
            Console.WriteLine($"That's why (a + b == 0.3) returns: {a + b == 0.3}"); // False
            Console.WriteLine();

            // --- Decimal example ---
            decimal d1 = 0.1m;
            decimal d2 = 0.2m;
            decimal sumDecimal = d1 + d2;

            Console.WriteLine($"Now we add d1 + d2 as decimal, where d1 = {d1} and d2 = {d2}");
            Console.WriteLine($"The result of d1 + d2 is {sumDecimal}, which IS equal to 0.3");
            Console.WriteLine($"That's why (d1 + d2 == 0.3m) returns: {d1 + d2 == 0.3m}"); // True
            Console.WriteLine();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}