using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== ANALISIS MATEMATICO: DOUBLE vs DECIMAL ===\n");

        // =========================
        // 1) DOUBLE
        // =========================
        double a = 0.1;
        double b = 0.2;
        double expected = 0.3;
        double sum = a + b;
        double error = sum - expected;

        Console.WriteLine("DOUBLE:");
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"a                 = {a:R}");
        Console.WriteLine($"b                 = {b:R}");
        Console.WriteLine($"a + b             = {sum:R}");
        Console.WriteLine($"expected (0.3)    = {expected:R}");
        Console.WriteLine($"error             = {error:R}");
        Console.WriteLine($"(a + b == 0.3)    = {sum == expected}");
        Console.WriteLine();

        // =========================
        // 2) DECIMAL
        // =========================
        decimal d1 = 0.1m;
        decimal d2 = 0.2m;
        decimal expectedDecimal = 0.3m;
        decimal sumDecimal = d1 + d2;
        decimal errorDecimal = sumDecimal - expectedDecimal;

        Console.WriteLine("DECIMAL:");
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"d1                = {d1}");
        Console.WriteLine($"d2                = {d2}");
        Console.WriteLine($"d1 + d2           = {sumDecimal}");
        Console.WriteLine($"expected (0.3m)   = {expectedDecimal}");
        Console.WriteLine($"error             = {errorDecimal}");
        Console.WriteLine($"(d1 + d2 == 0.3m) = {sumDecimal == expectedDecimal}");
        Console.WriteLine();

        // =========================
        // 3) COMPARACION MATEMATICA
        // =========================
        Console.WriteLine("ANALISIS:");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("double:");
        Console.WriteLine("0.1 + 0.2 = 0.30000000000000004 ≠ 0.3");
        Console.WriteLine("error = (0.1 + 0.2) - 0.3");
        Console.WriteLine();

        Console.WriteLine("decimal:");
        Console.WriteLine("0.1m + 0.2m = 0.3m");
        Console.WriteLine("error = 0");
        Console.WriteLine();

        // =========================
        // 4) TOLERANCIA
        // =========================
        double tolerance = 1e-15;
        Console.WriteLine("TOLERANCIA (double):");
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"|error| < tolerance → {Math.Abs(error) < tolerance}");
    }
}