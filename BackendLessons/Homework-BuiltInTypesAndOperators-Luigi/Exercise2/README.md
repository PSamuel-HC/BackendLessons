# Are Records Value or Reference types?

## Value types
Are types that hold its data in its own space memory. 
* They are typically stored on the stack.
* When assigning one value type to another, the systems creates a copy of the data.

## Reference types
Are types that hold a memory adress (pointer) that points where the data is in the heap.
* When assigning one reference type to another, the adress is being copying but both variables would point to the same object in memory


## Class vs Struct
* The **Class** is a reference type that represents objects with methods that change overtime.
* The **Struct** is a value type that is used for small and simple data containers that are copied easily.


## Records
Is a special type of Class or Struct.

When working with Classes, the comparision between two objects results to be different even if they contain the same data because they have different addresses in memory. But when working with Records, , C# looks at the values inside in order to compare.

The are usually inmutable, once they are created, we can't change them. We would have to create a new copy with the changes we want.

Records also allow functionalities that allows working with data more easily like `.ToString()` methods that would print the entire data of the object and deconstruction that allows to unpack a record into variables `var (name, age) = person1;`.

### Differences between other types
* **Class vs Record**: A Class compares identity (Are you the same instance?). A Record compares data (Do you have the same values?).
* **Struct vs. Record**: A Struct is a value data type. A Record is a data tool that gives value data type behavior but with the power of a Class.


### Are Records Value or Reference types?
* `record` or `record class`: Is a **reference type**, it lives on the heap and just acts like a value type when you compare two of them.
* `record struct`: C# also allows you to create a record that is a **Value Type** that lives on the stack.
