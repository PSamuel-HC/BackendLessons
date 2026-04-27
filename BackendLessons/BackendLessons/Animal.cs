using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLessons
{
    public interface IAnimal
    {
        public void MakeSound();
    }

    public class AnotherAnimal : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("ASDF");
        }
    }

    public class AnotherStrangeAnimal: IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("8988");
        }
    }

    public abstract class Animal  ///Abstraction
    {
        public string Name { get; set; }

        private int _health;

        public virtual void MakeSound() => Console.WriteLine("QWERTY");

        public abstract void MakeSoundSecondary();

        public void Example() => Console.WriteLine("");
    }

    public class Dog : Animal  //Inheritance
    {
        public override void MakeSound()
        {
            Console.WriteLine("Another");
        }

        public override void MakeSoundSecondary()
        {

        }

        public void Run()
        {
            Console.WriteLine("Another");
        }
    }

    public class Cat : Animal  //Inheritance
    {
        public override void MakeSound()
        {
            Console.WriteLine("Miauu");
        }

        public override void MakeSoundSecondary()
        {
            throw new NotImplementedException();
        }
    }


}
