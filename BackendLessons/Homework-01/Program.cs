namespace Homework_01
{
    public record Person(string name, int age);
    internal class Program
    {
        static void Main(string[] args)
        {
            // ------------------------------------------------
            // 1. EXPLAIN THIS CODE
            // ------------------------------------------------
            Console.WriteLine("1. EXPLAIN THIS CODE");

            // A. DOUBLES
            Console.WriteLine("A. DOUBLES");
            // Check the problem
            double a = 0.1;
            double b = 0.2;
            bool isEqual = (a + b) == 0.3;
            Console.WriteLine($"Is Equal: {isEqual}"); // Is Equal = Output: False

            // I need to be careful, if I use string for check a and b value could be inexact
            Console.WriteLine($"Saved a: {a}\nSaved b: {b}");

            // At the beginning, we can think that our variables are exact, String Parsing rounds our variables, but let's force a real decimal analysis
            // Let's check real a and b values, I'm going to check first 18 decimal digits
            Console.WriteLine($"Real Saved a: {a:G18}\nReal Saved b: {b:G18}");

            // This is the reason when we verify the sum, the obtained results (boolean and number) are false, because a + b is NOT exact 0.3
            // a and b aren't exact, double neither float are exact
            Console.WriteLine($"Real Sum Result: {a:G18} + {b:G18}");
            Console.WriteLine($"{a:G18} + {b:G18} IS NOT 0.3");
            Console.WriteLine("\n\n");


            // B. DECIMALS
            Console.WriteLine("B. DECIMALS");
            decimal d1 = 0.1m;
            decimal d2 = 0.2m;
            isEqual = d1 + d2 == 0.3m;
            Console.WriteLine($"Is Equal: {isEqual}"); // Is Equal = Output: True
            // Expected Result: d1 + d2 == 0.3m // Output: True
            // It's true, but we can check some things about decimal values
            Console.WriteLine($"Saved d1: {d1}\nSaved d2: {d2}");

            // With {d1:F18} and {d2:F18} we can check first 18 decimal digits
            Console.WriteLine($"Real Saved d1: {d1:F18}\nReal Saved d2: {d2:F18}");
            // They are exact, this is the reason thar our result is true

            // FUN FACT: DECIMAL LIMITS
            Console.WriteLine("FUN FACT. DECIMAL LIMIT");
            decimal d3 = 0.0000000000000000000000000000003m;
            Console.WriteLine($"Saved d3: {d3}");
            // With {d3:F30} we can check first 30 decimal digits
            Console.WriteLine($"Real Saved d3: {d3:F30}");
            // The precisition of decimal values is 28 digits, after that limit, instead of saving an approximation, it'll ignore last digits
            Console.WriteLine("\n\n\n");




            // ------------------------------------------------
            // 2. RECORDS (VALUE OR REFERENCE TYPES?)
            // ------------------------------------------------
            Console.WriteLine("2. RECORDS (VALUE OR REFERENCE TYPES?)");
            // Explain why records in c# are value or reference

            /*
            SHORT ANSWER:  
                Record are Reference Type with Value Semantics (When we use Record without Struct)
                Reference because it's saved in Heap, there is a Reference to find in Heap
                But It has Value Semantics because Records rewrite equality methods as '==' or Equals()
            
            LONG ANSWER
                TYPES
                    We need to understand first what is Reference and Value Types.
                        * REFERENCE TYPE. Objects are saved in HEAP (shared memory), variables only save reference for finding the Object when it's necessary
                        * VALUE TYPE. Data is saved in STACK (quick local memory), it's the variable itself.
                
                COMPARISON PHENOMENOM
                    * When we compare REFERENCE TYPE VARIABLES, they'll be equal only if we're comparing same direction of Heap Store
                            if 2 Objects have different reference, their comparing will be False, even if they have same information
                    * When we compare VALUE TYPE VARIABLES, they'll compare values that are saving in Stack, 
                            if they have the same value, it'll be true

            CONCLUSION
                If we had worked with Classes, the result had to be false, because person1 and person2 are in different location in Heap
                But Records replace the 'Reference Comparison' with 'Value Comparison

                Record are Reference Type with Value Semantics
                Reference because it's saved in Heap, there is a Reference to find in Heap"
                But It has Value Semantics because Records rewrite equality methods as '==' or Equals()

            
             FUN FACT
                In C# 10+ we can use 'record struct' to force that value should be saved in Stack
             */

            // We can use the Record that we have at the top of this project
            Person person1 = new Person("German", 29);
            Person person2 = new Person("German", 29);
            Console.WriteLine("Person1: " + person1);
            Console.WriteLine("Person2: " + person2);

            Console.WriteLine("\n");
            // We can check that in this case, Person is a class, we has instanced two people, but let's compare
            Console.WriteLine(
              "person 1 + person2 Comparison Result: " + (person1 == person2)
            );
            Console.WriteLine("\n\n\n");




            /*
             CONCLUSION:
                
             
             */


            // ------------------------------------------------
            // 3. STRONG TYPES
            // ------------------------------------------------
            Console.WriteLine("3. STRONG TYPES");
            /*
             Strong typing means that every variable and every object has a well-defined type. \n
             The compiler enforces strict rules: you cannot perform operations that are
             incompatible with the type, preventing many errors at compile-time rather than runtime
             */

            // EXAMPLE A: Type Safety
            Console.WriteLine("EXAMPLE A: Type Safety");
            int number = 10;
            string text = number.ToString(); // If we tried "string text = number", we're going to have an error // ERROR: This won't compile. You can't implicitly turn an int into a string


            // EXAMPLE B: Method Signature
            Console.WriteLine("EXAMPLE B: Method Signature");
            void ProcessData(int value) { }
            ProcessData(52); // OK: It's no problem, we're using same types
            // ProcessData("Hello") // ERROR: We cannot use string in a int expected value


            // EXAMPLE C: Strong Typing vs Dynamic
            Console.WriteLine("EXAMPLE C: Strong Typing vs Dynamic");
            var price = 19.99;
            price = 20.50; // OK: No problem, var is expecting double values
            // price = "expensive"  // Here we are going to have a problem, we're trying to use a string instead of expected double
            // Even with 'var', C# is strongly typed. The type is inferred but FIXED

        }
    }
}
