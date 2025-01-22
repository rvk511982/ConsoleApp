using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.Polymorphism
{
    public class PolymorphismDemo
    {
    }

    public class Animal
    {
        public Animal() 
        {
            Console.WriteLine("Base Class Animal Constructor");
        }

        // Virtual method in the base class
        public virtual void MakeSound()
        {
            Console.WriteLine("The animal makes a sound");
        }
    }
    public class Dog : Animal
    {
        public Dog()
        {
            Console.WriteLine("Dog class Constructor");
        }
        // Override the virtual method in the derived class
        public override void MakeSound()
        {
            Console.WriteLine("The dog says: bark");
        }
    }
    public class Cat : Animal
    {
        public Cat()
        {
            Console.WriteLine("Cat class Constructor");
        }

        // Override the virtual method in the derived class
        public override void MakeSound()
        {
            Console.WriteLine("The cat says: meow");
        }
    }

}
