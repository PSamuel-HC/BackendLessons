
// Excercise 1.

Console.WriteLine("EXCERCISE 1");
Console.WriteLine("To help to explain why this happens we need to understand first how are this different types stored in memory.");
Console.WriteLine("To start we have the double, which follows the IEEE754 binary floating-point standard. Its size is 8 bytes distributed like this:");
Console.WriteLine(" 1 bit: Sign");
Console.WriteLine(" 11 bits: Exponent ");
Console.WriteLine(" 52 bits: Fraction ");
Console.WriteLine(" 1 bit: Sign");
Console.WriteLine("So it cannot store a 0.1 in binary because it doesn't have the space to store that number in binary");
double a = 0.1;
double b = 0.2;
Console.WriteLine($"double: 0.1 + 0.2 = {a + b}");
Console.WriteLine("So as you can see the sum is not quite 0.3 but it has a really small error which isn't really concerning, but it does not meet the equality required to return true as you can see next:");
Console.WriteLine($"double: 0.1 + 0.2 == 0.3: {a + b == 0.3}");


Console.WriteLine("=============================================================");
Console.WriteLine(" Now, for Decimal, that a total different story, since its no longer in base 2, its in base 10.");
Console.WriteLine(" When it uses base 10, its able to store the 0.3 exactly as its");
decimal d1 = 0.1m;
decimal d2 = 0.2m;
Console.WriteLine($"decimal: 0.1 + 0.2 = {d1 + d2}"); 
Console.WriteLine($"decimal: 0.1 + 0.2 == 0.3: {d1 + d2 == 0.3m}"); // True

Console.WriteLine("So it's clear why this happens, so we need to be able to understand when to use them");

// The CORRECT way to compare doubles
double result = 0.1 + 0.2;
double epsilon = 1e-10;
Console.WriteLine($"double safe comparison: {Math.Abs(result - 0.3) < epsilon}"); // True, safely

// Numbers that DO work in double (denominator is a power of 2)
Console.WriteLine($"\ndouble: 0.25 + 0.25 == 0.5: {0.25 + 0.25 == 0.5}"); // True - exact in binary
Console.WriteLine($"double: 0.5  + 0.25 == 0.75: {0.5 + 0.25 == 0.75}"); // True - exact in binary
Console.ReadLine();




