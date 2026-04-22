
/** See README for full expanaltion.
 * Run with "dotnet run" command on the terminal to check result
 */
double a = 0.1;
double b = 0.2;
Console.WriteLine($"0.1 + 0.2 = {a + b}"); // Output: 0.1 + 0.2 = 0.30000000000000004
Console.WriteLine($"a (0.1) + b (0.2) == 0.3 -> {a + b == 0.3}"); // Output: False

decimal d1 = 0.1m;
decimal d2 = 0.2m;
Console.WriteLine($"0.1m + 0.2m = {d1 + d2}"); // Output: 0.1 + 0.2 = 0.3
Console.WriteLine($"d1 (0.1m) + d2 (0.2m) == 0.3m -> {d1 + d2 == 0.3m}"); // Output: True
