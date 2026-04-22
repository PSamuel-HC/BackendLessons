

#region 1. Analyze CODE    
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
    Console.WriteLine(a.ToString("F22"));
    Console.WriteLine((a+b).ToString("F22"));


    /*
     However, this is not the case with all non-integer numbers, 
     as there are some that can be correctly represented in binary, 
      mainly those with a power of 2 in the denominator.
     */

    Console.WriteLine("\nDouble numbers with correct binary representation");
    double c = 0.5;

    Console.WriteLine(c.ToString("F22")); // 1/2

    double x = 0.125;
    Console.WriteLine(x.ToString("F22")); // 1/8


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
#endregion


#region 2. RECORDS
//==============
Console.WriteLine("\n==============\nRecords: ");
//2. RECORDS:Explain why records in c# are value or reference types

//Explanation
/**
 *By default, a "Record" is usually of type "reference". 
 */


Car car1 = new Car("Toyota", "XYZ", "Blue"); //Default Record;

var car2 = car1;

//To verify this, we can do the following:
Console.WriteLine("Are they pointing to the same memory space?");

Console.WriteLine(Object.ReferenceEquals(car1, car2));


/*
 As you can see, it is a reference type. 
However, when comparing records, this type internally compares value by value.
That is, it behaves like a "value" type only when performing COMPARISONS.
 */

var car3 = new Car("Toyota", "XYZ", "Blue");

Console.WriteLine("Are car1 and car3 pointing to the same memory space?");
Console.WriteLine(Object.ReferenceEquals(car1, car3)); //FALSE

Console.WriteLine("Do they have the same values in their properties?");
Console.WriteLine(car1 == car3);

/*
 As you can see, unlike with classes, when we use equality comparison operators, we are comparing values,
 something that doesn't happen with classes, where a referential equality is made.
 */


//ON THE OTHER HAND, it is possible to use a "Record" entirely as a "Value" type, accompanying it with "Struct"

var carStruct1 = new CarStruct("Toyota", "XYZ", "Blue");
var carStruct2 = carStruct1;

Console.WriteLine("\nSTRUCT\nAre car1struct and carstruct2 pointing to the same memory space?");
Console.WriteLine(Object.ReferenceEquals(carStruct1, carStruct2));

//As you can see, what happens is that a copy of the data is sent when
//the assignment is made; the reference is not passed.


/*Finally, you can work with the record struct normally,
just like a normal STRUCT, but with new functionalities.*/

/*
 It is generally recommended to use a reference "Record" when dealing with very large objects,
and a value record with very small objects.
 */
#endregion


#region 3. Strong Typing
//========================
#endregion




public record Car(string Brand, string Model, string Color);

public record struct CarStruct(string Brand, string Model, string Color);