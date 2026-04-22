
// Double example
double a = 0.1;
double b = 0.2;
double sum1 = a + b;

Console.WriteLine("\nDOUBLE EXAMPLE:");

Console.WriteLine($"\nThe value of var 'a' seems to be 0.1: {a}");
Console.WriteLine("But after applying the multiplication algorithm to the decimal part we get");
Console.WriteLine("an infinite binary representation: 0.0001100110011... (0011 repeats infinitely)");

Console.WriteLine($"\nThe value of var 'b' seems to be 0.2: {b}");
Console.WriteLine("But after applying the multiplication algorithm to the decimal part we get");
Console.WriteLine("an infinite binary representation: 0.001100110011... (0011 repeats infinitely)");

Console.WriteLine($"\nThe value of 'a' + 'b' should be 0.3, but it is: {sum1}");

Console.WriteLine("\nBoth binary representations are unable to exactly represent 0.1 and 0.2.");
Console.WriteLine("In order to add them, their binary values are ROUNDED before the addition operation.");
Console.WriteLine("Finally, the imprecision is accumulated during the sum.");

Console.WriteLine($"\nThat explains why (a + b == 0.3) results in {a + b == 0.3}"); // False

Console.WriteLine("\n--------------------------------------------------------------------------------------");


// Decimal example
decimal d1 = 0.1m;
decimal d2 = 0.2m;
decimal sum2 = d1 + d2;

Console.WriteLine("\nDECIMAL EXAMPLE:");

Console.WriteLine($"\nThe value of 'd1' is exactly 0.1: {d1}");
Console.WriteLine($"The value of 'd2' is exactly 0.2: {d2}");

Console.WriteLine("\nDecimal type stores the decimal part this as a whole integer with a scaling factor (10^-1).");
Console.WriteLine("Because it uses base 10, there is no infinite binary representation.");

Console.WriteLine($"\nFinally, the value of 'd1' + 'd2' is: {sum2}");

Console.WriteLine("\nSince both 0.1 and 0.2 can be represented perfectly");
Console.WriteLine("no rounding is required before the sum and no error is accumulated.");

Console.WriteLine($"\nThat explains why (0.1m + 0.2m == 0.3m) results in {sum2 == 0.3m}"); // True

