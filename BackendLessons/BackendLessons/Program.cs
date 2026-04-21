namespace BackendLessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double largeValue = 1f; // One million
            double smallValue = 0.1f;      // One tenth

            double result = largeValue;

            for (int i = 0; i < 10; i++)
            {
                result += smallValue;
            }
            //1000001.0f
            Console.WriteLine(result);
        }
    }
}
