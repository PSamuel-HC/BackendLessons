# Homework - Broken Code

## Bug 1

### Cause:
The bug takes place in this lines of code:
```
UserProfile primaryUser = new UserProfile { UserName = "Alice", Rank = "Gold" };
UserProfile backupUser = primaryUser; // BUG: Reference Copy
```

* Since UserProfile is a class, creating backupUser with primaryUser would result in two variables that point to the same object.
* When performing an attribute modification like `backupUser.UserName = "Bob";`, the `primaryUser` object is also edited because both variables point to the same memory address in the heap.  

### Main Solution:
Avoid creating `backupUser` as a reference to the same object and create it as a copy of the class using its constructor and the `primaryUser` attributes.

```
UserProfile backupUser = new UserProfile { UserName = primaryUser.UserName, Rank = primaryUser.Rank };
```

### Other possible solutions (Not Implemented):
* Changing class UserProfile to struct UserProfile, the line `backupUser = primaryUser;` would automatically create a new independent copy on the stack.



## Bug 2

### Cause:
The bug takes place in this lines of code:
```
BankTransaction currentTx = new BankTransaction { Amount = 100.00m, IsVerified = false };
ProcessPayment(currentTx);
```
and
```
static void ProcessPayment(BankTransaction tx)
{
    tx.Amount += 50.00m;
    tx.IsVerified = true;
    Console.WriteLine("--- Internal: Payment processed successfully! ---");
}
```


* Since BankTransaction is a struct, receiving it as a parameter of a method would create and entire copy of the original instace.
* When performing an attribute modification such as `tx.Amount += 50.00m;` and `tx.IsVerified = true;`, the modification only affect the copy of the original instace.
* After the method finishes, the attributes of the original instace `currentTx.Amount` and `currentTx.IsVerified` have not been modified because only a copy was updated. 

### Main Solution:
The solution was adding the ref keyword on each the call and the method definition to specify the compiler to receive a reference rather than a copy:

```
ProcessPayment(ref currentTx);
```
and
```
static void ProcessPayment(ref BankTransaction tx)
```

### Other possible solutions (Not Implemented):
* Changing struct BankTransaction to class BankTransaction, the parameter `BankTransaction tx` would automatically receive a reference of the object instead of a copy.

## Bug 3
### Cause:
The bug takes place in this lines of code:
```
UserProfile guestUser = null;
PrintReport(guestUser);
```
and
```
static void PrintReport(UserProfile profile)
{
    Console.WriteLine($"USER REPORT: {profile.UserName.ToUpper()}");
}
```

* Since the class guestUser is being instantiated as null, the stack pointer is pointing to an invalid memory address of the heap.
* In the PrintReport, the profile parameter is referencing the same null memory address.
* Finally, accessing this null address to get the UserName attribute results in a crash of the program.


### Main Solution:
The solution was adding a conditional to check if profile is not null to know if we can access UserName attribute. If not, we can show an error messsage or any other results that is convenient. 

```
static void PrintReport(UserProfile profile) {
    if (profile != null) {
        Console.WriteLine($"USER REPORT: {profile.UserName.ToUpper()}");
    }
    else {
        Console.WriteLine($"PROFILE IS NULL");
    }
}
```

### Other possible solutions (Not Implemented):
* Using null-conditional operator `profile?.UserName.ToUpper() ?? "GUEST"`. This would have checked if profile was null before accesing to its attribute.