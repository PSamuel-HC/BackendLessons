

void CodeExplanation()
{

    // 1. ANALYZE THE BEHAVIOR OF FLOATING POINT PRECISION VS. DECIMAL TYPES IN C# EQUALITY CHECKS.

    double a = 0.1;
    double b = 0.2;

    Console.WriteLine(a + b == 0.3); // false

    decimal d1 = 0.1m;
    decimal d2 = 0.2m;

    Console.WriteLine(d1 + d2 == 0.3m); // true

    // EXPLANATION:

    /*
     * The behavior being experienced in this situation occurs mainly
     * due to how each data type internally represents non-integer numbers.
     */

    /*
     * When working with non-integer numbers using "double", it internally uses the IEEE 754 standard.
     * This standard works with powers of 2, so the problem is that there are several non-integer numbers 
        that, when represented in binary, generate an infinite fraction. For example, 0.1 (1/10) ---> 0.0001100...
     */

    //So, what is done internally to stop the infinite fraction is to approximate it to the nearest number

    //Therefore, if we look at the true representation of double numbers, we have the following:

    Console.WriteLine("\nReal representation of double numbers".ToUpper());
    Console.WriteLine(a.ToString("F20"));
    Console.WriteLine((a+b).ToString("F20"));


    /*
     However, this is not the case with all non-integer numbers, 
     as there are some that can be correctly represented in binary, 
      mainly those with a power of 2 in the denominator.
     */

    Console.WriteLine("\nDouble numbers with correct binary representation");
    double c = 0.5;

    Console.WriteLine(c.ToString("F20")); // 1/2

    double x = 0.125;
    Console.WriteLine(x.ToString("F20")); // 1/8


    /*
     On the other hand, the "decimal" type does not attempt to represent the number
    as powers of 2 or a binary fraction, 
    but rather works with base 10, representing numbers as follows:
    0.1 -----> 1/10^1.
     */

    
    //That's why, if we look at the representation of the values, it's exact.
    Console.WriteLine("\nDECIMAL NUMBER");
    Console.WriteLine(d1.ToString("F20"));


    //That's why: a + b == 0.3 -->>> FALSE and d1 + d2 == 03 --->> TRUE


}







CodeExplanation();