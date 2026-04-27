namespace BackendLessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

        }
    }
}
