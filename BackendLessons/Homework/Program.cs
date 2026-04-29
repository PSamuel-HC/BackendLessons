using JalaUniversity.BackendLessons;

Console.WriteLine("=== DataVault<User> ===");

var userVault = new DataVault<User>();

// Add users manually
var user1 = new User(Guid.NewGuid(), "alice");
var user2 = new User(Guid.NewGuid(), "bob");

userVault.AddItem(user1);
userVault.AddItem(user2);

// Test GetById
var found = userVault.GetById(user1.Id);
Console.WriteLine($"GetById result: {found}");

var notFound = userVault.GetById(Guid.NewGuid());
Console.WriteLine($"GetById (missing): {notFound ?? null}");

// Test CreateAndAdd
Console.WriteLine("\n--- CreateAndAdd ---");
var autoUser = userVault.CreateAndAdd();
Console.WriteLine($"Auto-created user: {autoUser}");

// DataVault<int> → FAILS to compile because:
// - int is not a reference type (class constraint fail s)
// - int does not implement IEntity


// var intVault = new DataVault<int>();  Compile error:
// "The type 'int' must be a reference type in order to use it
//  as parameter 'T' in the generic type or method 'DataVault<T>'"