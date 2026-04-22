# BackendLessons
Jala University Backend Lessons
Juan Sebastian Perea

To run this program, have dotnet installed and run on the terminal the following command:

```bash
dotnet run
```

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
binary to be stored requires a division to calculate the binary digits that represent that same
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