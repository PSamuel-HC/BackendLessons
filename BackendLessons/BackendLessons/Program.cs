namespace BackendLessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double largeValue = 1000000f; // One million
            double smallValue = 0.1f;      // One tenth

            double result = largeValue;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ITERATION: Nº  {i + 1}");
                Console.WriteLine("Result Previous Operation: " + result);
                Console.WriteLine("Small Value: " + smallValue);
                Console.WriteLine(result + " + " + smallValue);
                result += smallValue;
                Console.WriteLine("Result: " + result);
            }
            //1000001.0f
            Console.WriteLine(result);
        }
    }
}
