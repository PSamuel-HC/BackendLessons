
/** See README for full expanaltion.
 * Run with "dotnet run" command on the terminal to check result
 */

// First excersie example - Explain this code
Console.WriteLine("====================================");
Console.WriteLine("First excersice example:");
Console.WriteLine("====================================");
double a = 0.1;
double b = 0.2;
Console.WriteLine($"0.1 + 0.2 = {a + b}"); // Output: 0.1 + 0.2 = 0.30000000000000004
Console.WriteLine($"a (0.1) + b (0.2) == 0.3 -> {a + b == 0.3}"); // Output: False

decimal d1 = 0.1m;
decimal d2 = 0.2m;
Console.WriteLine($"0.1m + 0.2m = {d1 + d2}"); // Output: 0.1 + 0.2 = 0.3
Console.WriteLine($"d1 (0.1m) + d2 (0.2m) == 0.3m -> {d1 + d2 == 0.3m}"); // Output: True

// Second excersie example - Records
Console.WriteLine("\n");
Console.WriteLine("====================================");
Console.WriteLine("Second excersice example");
Console.WriteLine("====================================");
Console.WriteLine("\n");

Console.WriteLine("Value types are types for variables that holds their value.");
Console.WriteLine("When creating a copy with another variable, it copies the value");
int a1 = 1;
int b1 = a1;
Console.WriteLine($"a1 (int) == b1 (copy of a1) -> {a1 == b1} (this compares the value)");
Console.WriteLine($"object.ReferenceEquals(a1, b1) -> {object.ReferenceEquals(a1, b1)} (this compares the reference)");
Console.WriteLine("\n");
Console.WriteLine("Reference types are types for variables that holds their reference (memory address).");
Console.WriteLine("When creating a copy with another variable, it copies the address, so in the end, both variables points to the same value");
string a2 = "This is a reference variable";
string b2 = a2;
Console.WriteLine($"a2 (string) == b2 (copy of a2) -> {a2 == b2} (this compares the value)");
Console.WriteLine($"object.ReferenceEquals(a2, b2) -> {object.ReferenceEquals(a2, b2)} (this compares the reference)");

Person person1 = new Person("Juan", "Perea");
Person person2 = person1;
Console.WriteLine("\n");
Console.WriteLine("Now let's see what happens with records in both scenarios");
Console.WriteLine("Person person1 = new Person(\"Juan\", \"Perea\");");
Console.WriteLine($"person1 (Person) == person2 (copy of person1) -> {person1 == person2} (this compares the value)");
Console.WriteLine($"object.ReferenceEquals(person1, person2) -> {object.ReferenceEquals(person1, person2)} (this compares the reference)");
Console.WriteLine("The value and the reference are equal, but if we compare record structs...");
Console.WriteLine("\n");

Pet pet1 = new Pet("Apolo", "Cat");
Pet pet2 = pet1;
Console.WriteLine("public record struct Pet(string Name, string Species);");
Console.WriteLine($"pet1 (Pet) == pet2 (copy of pet1) -> {pet1 == pet2} (this compares the value)");
Console.WriteLine($"object.ReferenceEquals(pet1, pet2) -> {object.ReferenceEquals(pet1, pet2)} (this compares the reference)");
Console.WriteLine("The value is equal, but not the reference, which means a different object was created.");



// This has to go here for the code to run correctly
public record Person(string FirstName, string LastName);
public record struct Pet(string Name, string Species);