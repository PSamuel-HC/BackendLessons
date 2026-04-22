# Strong Typing in C#

In C#, strong typing is a fundamental concept that ensures every variable, constant, and expression has a specific type. This type is enforced by the compiler, which verifies that all operations performed on these variables are valid for their respective types.

For example, you can add two `int` values, but attempting to add an `int` and a `bool` will result in a compile-time error:

```csharp
int a = 5;
int b = a + 2; // OK

bool test = true;
// Error: Operator '+' cannot be applied to operands of type 'int' and 'bool'.
// int c = a + test;
```

This type safety feature helps catch errors before the code is executed, reducing the likelihood of runtime exceptions and improving code reliability.

---

## Variable Declarations

When declaring variables in C#, you can specify their types explicitly:

```csharp
int count = 10;
double temperature = 36.6;
```

Alternatively, you can use the `var` keyword for type inference, allowing the compiler to determine the type based on the assigned value:

```csharp
var name = "C#";
var items = new List<string> { "one", "two", "three" };
```

In both cases, the compiler enforces strong typing, ensuring that operations on these variables are valid for their types.

---

## Strong Typing in Methods

Strong typing also applies to method parameters and return values. For instance:

```csharp
static string GetGreeting(string name, int visitCount)
{
    return visitCount switch
    {
        1 => $"Welcome, {name}!",
        _ => $"Welcome back, {name}! Visit #{visitCount}."
    };
}
```

Here:

* The parameters (`string name`, `int visitCount`) are explicitly typed.
* The return type is also explicitly defined as `string`.
* The compiler ensures that only valid types are passed and returned.

---

## Key Benefits of Strong Typing

* **Early Error Detection**: Errors are caught at compile time instead of runtime.
* **Code Reliability**: Reduces unexpected behavior.
* **Better Readability**: Types make code easier to understand.
* **Tooling Support**: Improves IntelliSense and refactoring capabilities.

---

## Summary

Strong typing in C# ensures that:

* Every variable has a defined type.
* Operations are validated at compile time.
* Methods enforce correct input and output types.

This leads to safer, more maintainable, and more reliable code.
