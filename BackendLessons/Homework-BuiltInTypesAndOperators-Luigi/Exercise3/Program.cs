
Console.WriteLine("STRONG TYPING - C#");
Console.WriteLine("Means that every variable and object has a specific type that is strictly enforced.");
Console.WriteLine("The compiler prevents devs from performing operations that don't make sense.");



Console.WriteLine($"\n1. TYPE ENFORCEMENT");
int age = 25;
Console.WriteLine($"Age is an 'int' set to: {age}.");
Console.WriteLine("Trying 'age = \"twenty-five\";' would result in a compilation error.");
//age = "twenty-five";  // <- This will trigger an error



Console.WriteLine($"\n2. OPERATION SAFETY");
string name = "Alice";
int multiplier = 2;
Console.WriteLine($"With variables Name: {name}, Multiplier: {multiplier}.");
Console.WriteLine("Doesn't make sense to perform 'name * multiplier' because multiplication isn't defined for strings.");
// Console.WriteLine(name * multiplier); // <- This will trigger an error



Console.WriteLine($"\n3. EXPLICIT CASTING");
double pi = 3.14;
int roundedPi = (int)pi;
Console.WriteLine($"Original Double 'pi': {pi}.");
Console.WriteLine($"Cast to Int 'roundedPi': {roundedPi}.");
Console.WriteLine("C# forces devs to perform explicit casts '(int)pi'.");
Console.WriteLine("Trying 'roundedPi = pi' would result on a compilation error.");
//int roundedPi2 = pi; // <- This will trigger an error



Console.WriteLine($"\n4. FUNCTION SIGNATURE SAFETY");
void PrintAge(int userAge) {
    Console.WriteLine($"Method received 'int' value: {userAge}.");
}
Console.WriteLine($"Functions receive specific parameter types, PrintAge receives an int.");
Console.WriteLine($"Trying sending a string or any other type would trigger compilation errors.");
PrintAge(age);
//PrintAge("Unknown"); // <- This will trigger an error


