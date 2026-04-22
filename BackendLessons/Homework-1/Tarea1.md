# Homework-1

## Records (Value or Reference types)

It is a reference type, similar to a class, but specifically designed to represent immutable data and also to allow comparison by value, instead of by reference as classes do.

### Reference type (Record class)

It's a reference type (like a regular class), but with value comparison and immutability by default. It's a data-optimized class.

```
public record Persona(string Nombre, int Edad);

var p1 = new Persona("Juan", 25);
var p2 = new Persona("Juan", 25);

// ✔ Equality by value
Console.WriteLine(p1 == p2); // true

// ❌ Different objects in memory
Console.WriteLine(object.ReferenceEquals(p1, p2)); // false
```
They are two different objects.
But their data is the same so they are equal for c#.

When to use it

* API responses
* Data models
* DTOs

### Reference type (Record class)

It's a value type, like a `struct`, but with automatic value comparison and a simpler syntax.

Its characteristics are that it generally lives on the stack, is copied by value, compares by value, and is mutable by default but can be made immutable.

```
public record struct Punto(int X, int Y);

var p1 = new Punto(10, 20);
var p2 = p1; // copia

p2.X = 50;

Console.WriteLine(p1.X); // 10 (does not change)
Console.WriteLine(p2.X);
```

p2 is an independent copy; changing one does not affect the other.

* Immutable version

```
public readonly record struct Punto(int X, int Y);

var p1 = new Punto(10, 20);
var p2 = p1; // copia

p2.X = 50; // ❌ init-only property or readonly field cannot be assigned to

Console.WriteLine(p1.X); // 10 (does not change)
Console.WriteLine(p2.X);
```


## Strong typing in C#

Strong typing in C# means that each variable has a defined type, and the language does not allow mixing incompatible types without explicit conversion, we cannot perform operations between different types for example adding a number to a text. This helps prevent errors and makes code safer and more predictable.

Examples:

```
int numero = 10;
string texto = "20";

int resultado = numero + texto; // ❌ Compilation error (You cannot convert a string to an int)
```
Convert the string to int

```
int number = 10;
string text = "20";

int converted = int.Parse(text);
int result = number + converted;

Console.WriteLine(result); // 30
```

We try to convert an string to int

```
int numero = 10;
string texto = "Hola";
int convertido = int.Parse(texto); // ❌ The input string 'Hola' was not in a correct format
int resultado = numero + convertido;
```

