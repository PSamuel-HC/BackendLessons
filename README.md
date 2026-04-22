# BackendLessons
Jala University Backend Lessons
Juan Sebastian Perea

To run this program, have dotnet installed and run on the terminal the following command:

```bash
dotnet run
```

Note: if a warning like this appears

```bash
Do not pass an argument with value type 'int' to 'ReferenceEquals'. Due to value boxing, this call to 'ReferenceEquals' can return an unexpected result. Consider using 'Equals' instead, or pass reference type arguments if you intend to use 'ReferenceEquals'. (https://learn.microsoft.com/dotnet/fundamentals/code-analysis/quality-rules/ca2013)
```
That's expected. Is for the excersice purposes.

## Excersice 1 - Explain this code

```csharp
double a = 0.1;
double b = 0.2;
Console.WriteLine(a + b == 0.3); // Output: False

decimal d1 = 0.1m;
decimal d2 = 0.2m;
Console.WriteLine(d1 + d2 == 0.3m); // Output: True
```

As we saw on the last session, and according to the IEEE 754 standard, converting a decimal to
binary to be stored requires an operation to calculate the binary digits that represent that same
decimal number. But the only way that the decimal number gets an exact binary number is that the
decimal part is represented by the division of 1 by a power of 2 (1/2ⁿ), so numbers like 0.5 (1/2),
0.25 (1/4), 0.125 (1/8) etc are the only ones getting an exact binary, the rest will be represented
by a binary with infinite decimals.

Being infinite, this number will not be able to be stored exactly, so the program will decide
to store the number to a certain extension, depending on the number of bits available on the variable,
and this depends on the data type. So a double will only have available 64 bits (8 bytes), and from
those, 1 bit is used to stored the sign, and 8 for the exponent, so 55 bits are really used for the
binary digits representing the decimal number.

In the case of 0.1 (1/10) and 0.2 (1/5), 10 and 5 are not power of 2, so the decimal to binary 
conversion will never give an exact number of binary digits (as you can see on [Program.cs](Program.cs),
0.1 double is really something like 0.100000000000000005551... and 0.2 is something like
0.20000000000000001110223... and when the program computes those 2 numbers and do an approximation,
the final result is somtehing like 0.300000000000000044408... or 0.30000000000000004 for our case.

Using **decimal** solves this to some extend, not only because it has more bytes (16), but because this
data type tries to store the number in decimal base, so 0.1 is actually stored as 1 (and the program
knows that when is used, it has to divide it again by 10 to have 0.1 again). This allows to have more
precise calculations, because 0.1m, 0.2m and 0.3m are actually 0.1, 0.2 and 0.3.


## Excersice 2 - Records, are they value or reference type?
Value types are the data types that stores the value itself, and when creating another variable and 
assign the contents of the first variable, what is copied is the value itself
```csharp
int a = 1;
int b = a // b is receiving 1;
```

Reference types are data types that stores the reference of the value, which means, the memory address
of that value. So when copying a variable to another, what is actually coping is the memory address
of that value.
```csharp
string a = "Hello World";
string b = a // b is the memory address of the value "Hello World";
```

Records are mostly a reference type used to create an immutable object, primarily for encapsulating data,
so they can be used for example to create DTOs, or any other reference to a data shape. Only when used
with structs, they behave as value type. See [Program.cs](Program.cs) to have a clear example of this.

## Excercise 3 - Strong typing
Languages like Python and Javascript allows devs to create variables without specifying a type,
like this:
```javascript
const a = 1;
let b = "hello";
b = 3;
let c;
```
As you see in the example, there is no rule for changing a variable from one type to another (b), or even
creating a variable (c) that we won't know its type until a value is assigned.

In staticaly, strong typed languages like C#, C, Java and others, you must assign a type to a variable
when creating it.
```csharp
int number1 = 1;
int number2 = 5;
string word1 = "hello";
number1 = "World"; // This will cause a compilation error, trying to switch types
Console.WriteLine(number2 * word1) // This will also cause an error, trying to operate two different types
```
In these cases, the compiler will make sure that the variables are assigned and used correctly, including some operatrions
like multiplying a string with a number (surprisingly, adding a string an a number works, but it will "cast" the int
to a string). Talking about casting, is the process of converting on the run one variable to another, but it only works
with certain types, for example from a int to a double.

See [Program.cs](Program.cs) to check some error examples of this. The lines are commented to avoid all the program to
crash, so is necessary to uncomment the lines.

In C#, there is an exception, with the dynamic type, which has a similar behavior to the object type, with
the difference that it won't be type checked at compile time.