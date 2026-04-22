// Exercise 2.

Console.WriteLine("EXERCISE 2");
Console.WriteLine("Now, to understand this exercise we need to understand what is a reference type");
Console.WriteLine("When you create a regular class, the variable doesn't hold the object, it holds a pointer to where the object lives in memory (heap)");


var c1 = new PersonClass("Alice", 30);
var c2 = new PersonClass("Alice", 30);
Console.WriteLine("So when we have two classes with the same data:");
Console.WriteLine(c1);
Console.WriteLine(c2);
Console.WriteLine("And we ask if they are the same using ==:");
Console.WriteLine($"class: c1 == c2: {c1 == c2}");
Console.WriteLine("It returns false because a regular class compares by memory address, not by value");


Console.WriteLine("This is where we use RECORDS. Records override == to compare by value");
var p1 = new Person("Alice", 30);
var p2 = new Person("Alice", 30);
var p3 = p1;
Console.WriteLine("So when we have two records with the same data:");
Console.WriteLine(p1);
Console.WriteLine(p2);
Console.WriteLine($"record: p1 == p2 (same data, different objects): {p1 == p2}");
Console.WriteLine("It returns true because records compare by content, not by memory address");

Console.WriteLine("but they are still reference types, they still live on the heap:");
Console.WriteLine($"ReferenceEquals(p1, p2): {ReferenceEquals(p1, p2)}");
Console.WriteLine("referenceEquals returns false - they are different objects in memory");

Console.WriteLine("but if p3 = p1, they point to the SAME object in memory:");
Console.WriteLine($"ReferenceEquals(p1, p3): {ReferenceEquals(p1, p3)}");
Console.WriteLine("Now ReferenceEquals returns true because p3 is just another name for p1");


Console.WriteLine("Finally, a record struct is a true value type, it lives on the STACK not the heap:");
var s1 = new PersonStruct("Bob", 25);
var s2 = new PersonStruct("Bob", 25);
Console.WriteLine(s1);
Console.WriteLine(s2);
Console.WriteLine($"record struct: s1 == s2: {s1 == s2}");
Console.WriteLine("It returns true because value types always compare by content");
Console.WriteLine("and we can not use ReferenceEquals since they live in the stack");


Console.ReadLine();


record Person(string Name, int Age);

class PersonClass(string Name, int Age)
{
    public string Name { get; } = Name;
    public int Age { get; } = Age;
    public override string ToString() => $"PersonClass {{ Name = {Name}, Age = {Age} }}";
}

record struct PersonStruct(string Name, int Age);