namespace BackendLessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float largeValue = 1000000.0f; // One million
            float smallValue = 0.1f;      // One tenth

            float result = largeValue;

            for (int i = 0; i < 10; i++)
            {
                result += smallValue;
            }
            //1000001.0f
            Console.WriteLine(result);
        }
    }
}
