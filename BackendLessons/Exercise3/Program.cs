// Exercise 2.

Console.WriteLine("EXERCISE 3");

Console.WriteLine("Strong typing means every variable has a fixed type that the compiler knows at compile time.");
Console.WriteLine("You cannot mix incompatible types without being explicit about it.");

Console.WriteLine("Implicit vs Explicit conversion");
Console.WriteLine("Going from int to double is safe, no data can be lost, so C# allows it automatically:");
int myInt = 10;
double myDouble = myInt;
Console.WriteLine($"int myInt = 10, then double myDouble = myInt gives us: {myDouble}");
Console.WriteLine("But going from double to int is dangerous, you could lose the decimal part.");
Console.WriteLine("So C# forces you to be explicit with a cast:");
int Int = (int)myDouble;
Console.WriteLine($"(int)myDouble gives us: {Int}");
Console.WriteLine("The cast is your way of telling the compiler: I know I might lose data and I am okay with it.\n");


Console.WriteLine("String conversions");
Console.WriteLine("C# will never automatically convert a string to a number.");
Console.WriteLine("What if the string was 'hello' instead of '42'? There is no safe automatic conversion.");
Console.WriteLine("So you must explicitly call int.Parse():");
string input = "42";
int parsed = int.Parse(input);
Console.WriteLine($"int.Parse(\"42\") gives us: {parsed}");
Console.WriteLine("But Parse is dangerous, it crashes if the string is not a number.");
Console.WriteLine("The safer way is TryParse, which returns false instead of crashing\n");

Console.WriteLine("Type safety in methods");
Console.WriteLine("A method signature is a contract, it only accepts the types you define.");
Console.WriteLine("CalculateArea (double radius) => Math.PI * radius * radius"); 
Console.WriteLine("CalculateArea only accepts a double, nothing else:");
Console.WriteLine($"CalculateArea(5.0) gives us: {CalculateArea(5.0)}");
Console.WriteLine("If you try CalculateArea(\"5\") or CalculateArea(5) the compiler rejects it immediately.\n");


Console.WriteLine("var is still strongly typed");
Console.WriteLine("A common misconception is that var means any type, like in JavaScript.");
Console.WriteLine("In C#, var just means: compiler, figure out the type for me.");
var inferredInt = 42;
var inferredStr = "hello";
Console.WriteLine($"var inferredInt = 42, the compiler decided its type is: {inferredInt.GetType().Name}");
Console.WriteLine($"var inferredStr = \"hello\", the compiler decided its type is: {inferredStr.GetType().Name}");
Console.WriteLine("Once that type is decided at compile time, it is fixed forever.");
Console.WriteLine("Trying to do inferredInt = \"hello\" won't compile, it is still an int!\n");

Console.ReadLine();

static double CalculateArea(double radius) => Math.PI * radius * radius;