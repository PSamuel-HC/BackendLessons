# C# Records

In C#, records are a special type of reference type that provide built-in functionality for encapsulating data. The `record` modifier can be applied to either a class or a struct.

## Types of Records

### record class (Reference Type)

* Defines a **reference type**.
* Instances hold a reference to data in memory.
* Changes made through one variable affect all references to that instance.

### record struct (Value Type)

* Defines a **value type**.
* Each instance contains its own copy of the data.
* Changes to one instance do **not** affect others.

---

## Examples

### Record Class (Reference Type)

```csharp
public record Person(string FirstName, string LastName);
```

In this example, `Person` is a record class. Multiple variables can reference the same instance, so modifying one affects the others.

### Record Struct (Value Type)

```csharp
public readonly record struct Point(double X, double Y);
```

Here, `Point` is a record struct. Each instance is independent, so modifying one does not affect another.

---

## Key Features of Records

### 1. Built-in Equality

* Records use **value-based equality**.
* Two instances with the same values are considered equal.
* Unlike regular classes, which use reference equality.

### 2. Nondestructive Mutation

* Use the `with` expression to create a modified copy:

```csharp
var person1 = new Person("Nancy", "Davolio");
var person2 = person1 with { FirstName = "John" };
```

### 3. Immutability

* Positional properties are **immutable by default**.
* You can make them mutable if needed, but immutability is preferred.

---

## When to Use Records

Use records when:

* The type is primarily used to **store data**.
* You want **value-based equality**.
* You prefer **immutability** for safety and consistency.
* You want a clean and readable `ToString()` automatically.

---

## Summary

Records in C# provide a concise and powerful way to define data-centric types with built-in support for:

* Value equality
* Immutability
* Easy data manipulation

They are ideal for scenarios where data representation is the main purpose, distinguishing them from traditional classes and structs.