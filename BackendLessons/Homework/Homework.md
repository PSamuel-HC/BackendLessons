# Homework

_By Gerónimo Le Lan Toussaint_

## 1. Explain this code

```csharp
double a = 0.1;
double b = 0.2;
Console.WriteLine(a + b == 0.3); // Output: False

decimal d1 = 0.1m;
decimal d2 = 0.2m;
Console.WriteLine(d1 + d2 == 0.3m); // Output: True
```

### Why the first comparison returns False

The problem comes from the fact that **`double` stores numbers in binary (base 2), not in decimal**.

Most decimal fractions cannot be represented exactly in binary. `0.1` in binary is an **infinite repeating pattern** (`0.0001100110011...`), just like `1/3` is infinite in base 10 (`0.333...`).

Since a `double` has a limited number of bits, it has to **cut off and round** the representation. What actually gets stored is a tiny bit more or less than `0.1`. The same happens to `0.2` and `0.3`.

When you add `0.1 + 0.2`, the result is a slightly different approximation than the one stored in `0.3`, so `==` returns **False**.

This is not a C# bug — it happens in every language that uses IEEE 754 (JavaScript, Python, Java, C, C++, Go...).

### Why the second comparison returns True

`decimal` uses **base 10** internally, not binary. It stores `0.1m` as the integer `1` with a scale of `1` (meaning `1 × 10⁻¹`), so the value is **exact**.

Since `0.1m`, `0.2m`, and `0.3m` are all stored exactly, the arithmetic is exact and `==` returns **True**.

### Decimal have limits

 `decimal` is 128 bits and has:

- Maximum **28-29 significant digits**
- Range roughly **±7.9 × 10²⁸**
- Up to **28 decimal places**

It can still fail with numbers that are also infinite in base 10 (like `1/3`), or when the value exceeds those limits.



## 2. Records (Value or Reference types?)

`record` in C# is a **reference type** by default.
`record struct` is a **value type**.

The `record` keyword doesn't introduce a new category of type — it's syntactic sugar on top of either `class` or `struct` that adds:

- **Value-based equality** (two records are equal if their data is equal)
- **`with` expressions** (non-destructive mutation)
- A nice `ToString()` that prints properties
- Deconstruction support

### Examples

```csharp
public record Person(string Name, int Age);          // reference type
public record class Employee(string Name, int Id);   // reference type (explicit)
public record struct Point(double X, double Y);      // value type
```

### Value-based equality

```csharp
var p1 = new Person("Alice", 30);
var p2 = new Person("Alice", 30);

Console.WriteLine(p1 == p2);                 // True — same data
Console.WriteLine(ReferenceEquals(p1, p2));  // False — different objects
```

A normal class would return `False` for `==` because it compares references, not data.

### Why reference type by default?

- Records are commonly used for DTOs and models, often too large to copy efficiently.
- Reference semantics allow **inheritance** between records.
- The value-based equality feature works fine on a class — the compiler just generates `Equals` and `GetHashCode` for you.

`record struct` is available when you explicitly want value semantics (small, stack-friendly types).

---

## 3. Strong Typing in C#

**Strong typing** means the language enforces type rules strictly. Every variable and expression has a well-defined type, and the compiler prevents operations that are invalid for that type.

C# is both **strongly** and **statically** typed: types are checked at compile time and mismatches are errors, not silent conversions.

### Example 1 — Type mismatches are compile errors

```csharp
int number = 10;
string text = "hello";
// int result = number + text;  // Compile error
```

In JavaScript this would silently produce `"10hello"`. In C# it's a hard stop.

### Example 2 — Variables keep their type

```csharp
int age = 25;
// age = "twenty-five";  // Compile error

var x = 10;      // x is inferred as int, permanently
// x = "hello"; // Still a compile error
```

### Example 3 — Explicit conversions required

```csharp
double d = 3.7;
// int i = d;      // Error — implicit narrowing not allowed
int i = (int)d;    // OK — explicit cast, i = 3

string s = "42";
int n = int.Parse(s);  // Explicit conversion
```

### Example 4 — Generics enforce element type

```csharp
List<int> numbers = new() { 1, 2, 3 };
// numbers.Add("four");  // Compile error

int first = numbers[0]; // no cast needed, compiler knows the type
```

### Example 5 — `dynamic` as an opt-in escape hatch

```csharp
dynamic x = 10;
x = "hello";         // allowed
x.DoSomething();     // compiles, but can throw at runtime
```

`dynamic` opts out of compile-time checking for specific variables — useful for interop, but not the default behavior.

### Benefits

- **Early error detection** — most bugs caught before running the code.
- **Better tooling** — IntelliSense, refactoring, and navigation rely on types.
- **Self-documenting** — method signatures describe expected inputs and outputs.
- **Performance** — the JIT can optimize with full type information.
- **Safer refactoring** — the compiler points out every place that breaks after a change.
