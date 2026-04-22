namespace Homework_01
{
    public record Person(string name, int age);
    internal class Program
    {
        static void Main(string[] args)
        {
            // EXPLAIN THIS CODE
            Console.WriteLine("1. EXPLAIN THIS CODE");
            double a = 0.1;
            double b = 0.2;

            Console.WriteLine("----");
            Console.WriteLine("double a = 0.1;");
            Console.WriteLine("double b = 0.2;");
            Console.WriteLine("----");
            Console.WriteLine("Expected Result: a + b == 0.3 // Output: False");
            Console.WriteLine($"Current Boolean Result: {a + b == 0.3}");
            Console.WriteLine($"Current Real Result: {a + b}");
            Console.WriteLine("Explanation");
            Console.WriteLine("First, we can check that the Real Result is an approximation, let's check real a and b values");
            Console.WriteLine($"Saved a: {a}");
            Console.WriteLine($"Saved b: {b}");
            Console.WriteLine("At the beginning, we can think that our variables are exact, String Parsing rounds our variables, but let's force a real decimal analysis");
            Console.WriteLine("With {a:G17} and {b:G17} we're going to realize what's happening with first 18 decimal values");
            Console.WriteLine($"Real Saved a: {a:G18}");
            Console.WriteLine($"Real Saved b: {b:G18}");
            Console.WriteLine("This is the reason when we verify the sum, the obtained results (boolean and number) are false");
            Console.WriteLine();
            Console.WriteLine();

            decimal d1 = 0.1m;
            decimal d2 = 0.2m;
            // EXPLAIN THIS CODE
            Console.WriteLine("----");
            Console.WriteLine("decimal d1 = 0.1m;");
            Console.WriteLine("decimal d2 = 0.2m;");
            Console.WriteLine("----");
            Console.WriteLine("Expected Result: d1 + d2 == 0.3m // Output: True");
            Console.WriteLine($"Current Boolean Result: {d1 + d2 == 0.3m}");
            Console.WriteLine($"Current Real Result: {d1 + d2}");
            Console.WriteLine("It's true, but we can check some things about decimal values");
            Console.WriteLine($"Saved d1: {d1}");
            Console.WriteLine($"Saved d2: {d2}");
            Console.WriteLine("With {d1:F18} and {d2:F18} we can check first 18 decimal digits");
            Console.WriteLine($"Real Saved d1: {d1:F18}");
            Console.WriteLine($"Real Saved d2: {d2:F18}");
            Console.WriteLine("They are exact, this is the reason thar our result is true, but decimal has its weakness, for example");
            decimal d3 = 0.0000000000000000000000000000003m;
            Console.WriteLine("----");
            Console.WriteLine("decimal d3 = 0.0000000000000000000000000000003m;");
            Console.WriteLine("----");
            Console.WriteLine($"Saved d3: {d3}");
            Console.WriteLine("With {d3:F30} we can check first 30 decimal digits");
            Console.WriteLine($"Real Saved d3: {d3:F30}");
            Console.WriteLine("The precisition of decimal values is 27 to 28 digits, after that limit, instead of saving an approximation, it'll ignore last digits");
            Console.WriteLine();
            Console.WriteLine();



            Console.WriteLine("2. RECORDS (VALUE OR REFERENCE TYPES?)");
            Console.WriteLine("Explain why records in c# are value or reference\n");
            Console.WriteLine(
                "We need to understand first what is Reference and Value Types.\n" +
                "REFERENCE TYPE. Objects are saved in Heap (shared memory), variables only save reference for finding the Object when it's necessary\n" +
                "VALUE TYPE. Data is saved in Stack (quick local memory), it's the variable itself. \n" +
                "\n" +
                "COMPARING PHENOMENOM\n" +
                "When we compare REFERENCE TYPE VARIABLES, they'll be equal only if we're comparing same direction of Heap Store, if 2 Objects have different reference, their comparing will be False, even if they have same information\n" +
                "When we compare VALUE TYPE VARIABLES, they'll compare values that are saving in Stack, if they have the same value, it'll be true\n" +
                "\n" +
                "REFERENCE RECORD TYPE\n" +
                "To be honest, It's a type of reference with value semantic\n" +
                "REFERENCE.\n" +
                "public record Person(string name, int age);\n" +
                "It's a class, we can create Object using 'Person', those Object will be stored in Heap\n"
            );
            Person person1 = new Person("German", 29);
            Person person2 = new Person("German", 29);

            Console.WriteLine(
                "" +
                "Person german = new Person(\"German\", 29);\n" +
                "Person german = new Person(\"German\", 29);\n" +
                "We can check that in this case, Person is a class, we has instanced two people, but let's compare\n"
            );

            Console.WriteLine(
                "person1 == person2\n" +
                "Result: " + (person1 == person2)
            );

            Console.WriteLine(
                "If we had worked with Classes, the result had to be false, because aaron and german are in different location in Heap\n" +
                "But Records replace the 'Reference Comparison' with 'Value Comparison'\n"
            );

            Console.WriteLine(
                "CONCLUSION:\n" +
                "Record are Reference Type with Value Semantics\n" +
                "Reference because it's saved in Heap, there is a Reference to find in Heap" +
                "But It has Value Semantics because Records rewrite equality methods as '==' or Equals()"
            );

            Console.WriteLine(
                "FUN FACT\n" +
                "In C# 10+ we can use 'record struct' to force that value should be saved in Stack"
            );
            Console.WriteLine("\n\n");

            Console.WriteLine("3. STRONG TYPES");
            Console.WriteLine("Define 'Strong Typing' and provide code examples demonstrating its implementation");
            Console.WriteLine(
                "Strong typing means that every variable and every object has a well-defined type. \n" +
                "The compiler enforces strict rules: you cannot perform operations that are \n" +
                "incompatible with the type, preventing many errors at compile-time rather than runtime."
            );

            Console.WriteLine("EXAMPLE A: Type Safety");
            // EXAMPLE
            int number = 10;
            string text = number.ToString(); // If we tried string text = number, we're going to have an error
            
            Console.WriteLine("" +
                "int number = 10;\n" +
                "string text = number.ToString(); // string text = number; \n// ERROR: This won't compile. You can't implicitly turn an int into a string\n" +
                $"Console.WriteLine($\"Number to String: {text}\");"
            );



            Console.WriteLine("EXAMPLE B: Method Signature\n");
            // EXAMPLE
            void ProcessData(int value) { }
            ProcessData(10); // OK: It's no problem, we're using same types
            // ProcessData("Hello") // ERROR: We cannot use string in a int expected value

            Console.WriteLine("void ProcessData(int value) { }");
            Console.WriteLine("If we try\n" +
                "ProcessData(\"Hello\")    // ERROR: The compiler knows \"Hello\" is a string, but the method needs an int."
            );
            Console.WriteLine(
                "ProcessData(10); // No Error, it's correct format\n"
            );
            Console.WriteLine("The compiler blocks calling methods with the wrong data types.");


            Console.WriteLine("EXAMPLE C: Strong Typing vs Dynamic");
            // EXAPLE
            var price = 19.99;
            price = 20; // OK: No problem, var is expecting double values
            // price = "expensive"  // Here we are going to have a problem, we're trying to use a string instead of expected double

            Console.WriteLine(
                "var price = 19.99;\n" +
                "price = 20; \n" +
                "Even with 'var', C# is strongly typed. The type is inferred but FIXED.\n" +
                "price = \"expensive\"; // ERROR: 'price' is a double, it cannot become a string later."
            );
        }
    }
}
