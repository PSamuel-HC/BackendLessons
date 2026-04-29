using Jalasoft.GoldenRecord;
using System.Collections;

namespace BackendLessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double largeValue = 1000000f; // One million
            double smallValue = 0.1f;      // One tenth
            int[] integerArray = new int[8]; //empty

            int[] integerArray2 = { 4, 5, 8 }; //inline element

            int size = integerArray.Length;

            integerArray.Sort();

            integerArray.Reverse();

            int indexFound = integerArray2.IndexOf(8);

            Console.WriteLine(indexFound);

            integerArray2.Contains(8);

            UserProfile[] userArray = new UserProfile[5];

            //for (int i = 0; i < integerArray2.Length+1; i++)
            //{
            //    int current = integerArray2[i];
            //}

            //List
            List<UserProfile> userList = new List<UserProfile>();

            userList.Add(new UserProfile(4, 8));
            userList.Add(new UserProfile(4, 8));
            userList.Add(new UserProfile(4, 8));
            userList.Add(new UserProfile(4, 8));
            userList.Add(new UserProfile(4, 8));

            int capacity = userList.Capacity;

            int sizeList = userList.Count;

            //Console.WriteLine(capacity);
            //Console.WriteLine(sizeList);



            //int indexFound = 

            //Console.WriteLine(indexFound);

            //userList.Add(new UserProfile(4, 8));


            ///Polimorfismo

            Animal animalTest = new Dog();

            ((Dog)animalTest).Run();

            animalTest.MakeSound();

            animalTest.Example();

            Animal cat = new Cat();

            cat.Run();

            cat.MakeSound();




            IAnimal animal = new AnotherAnimal();

            IAnimal animal2 = new AnotherStrangeAnimal();

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
            Response<User> userResponse = new Response<User>();

            Response<Product> productResponse = new Response<Product>();

            Response<Page<User>> userPaginatedResponse = new Response<Page<User>>();

            Repository<User> product = new Repository<User>();

        }
    }
}
