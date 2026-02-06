/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #1

This program demonstrates concepts we have learned in 
class recently, including interfaces, polymorphism, 
and visibility modifiers.
*/

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;

namespace animalPolymorphism
{
    // abstract class to represent an animal 
    public abstract class Animal
    {
        // public auto-properties 
        public string Name {get; set;}
        public int Age {get; set;}

        // private fields
        private int _energy = 100;

        // protected methods
        protected void DecreaseEnergy(int amount)
        {
            _energy -= amount;  // decrease energy by given amount
        }

        // abstract methods 
        public abstract void MakeSound();
    }

    // define interfaces to demonstrate multiple inheritance of behavior 
    public interface ICanRun
    {
        void Run();
    }

    public interface ICanSwim
    {
        void Swim();
    }

    // concrete classes that inherits abstract class and implements interfaces 
    // class to represent a Dog object
    public class Dog: Animal, ICanRun
    {
        // methods
        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }

        public void Run()
        {
            Console.WriteLine($"{Name} is running!");
        }
    }

    // class to represent a Fish object 
    public class Fish: Animal, ICanSwim
    {
        // methods 
        public override void MakeSound()
        {
            Console.WriteLine("Blub blub!");
        }

        public void Swim()
        {
            Console.WriteLine($"{Name} is swimming!");
        }
    }

    // class to represent a Duck object 
    public class Duck: Animal, ICanRun, ICanSwim
    {
        // methods 
        public override void MakeSound()
        {
            Console.WriteLine("Quack!");
        }

        public void Run()
        {
            Console.WriteLine($"{Name} is waddling!");
        }

        public void Swim()
        {
            Console.WriteLine($"{Name} is paddling in water!");
        }
    }

    // zoo class which contains a private polymorphic array of animal objects
    public class Zoo
    {
        // properties 
        private Animal[] animalZoo = new Animal[10];
        private int animalsInZoo = 0; // used to keep track of place in array

        // methods
        // adds an animal to the array
        public void AddAnimal(Animal animal)
        {
            // if there are greater than 10 animals in the zoo
            if (animalsInZoo >= 10)
            {
                Console.WriteLine("> The zoo capacity has been exceeded");
                return;
            }
            // add animal to the zoo
            animalZoo[animalsInZoo] = animal;
            animalsInZoo++; // increment
        }

        // calls MakeSound() on all animals in the array
        public void MakeAllAnimalsSound()
        {
            // iterate through all animals in zoo
            for (int i = 0; i < animalsInZoo; i++)
            {
                animalZoo[i].MakeSound();
            }
        }

        // calls Run() on all animals that implement ICanRun
        public void ShowRunningAnimals()
        {
            // iterate through all animals in zoo
            for (int i = 0; i < animalsInZoo; i++)
            {
                // check if animal implements ICanRun interface
                if (animalZoo[i] is ICanRun runner)
                {
                    runner.Run();   
                }
            }
        }

        // calls Swim() on all animals that implement ICanSwim
        public void ShowSwimmingAnimals()
        {
            // check if animal implements ICanSwim interface
            for (int i = 0; i < animalsInZoo; i++)
            {
                if (animalZoo[i] is ICanSwim swimmer)
                {
                    // cast so that there is no compile time error
                    swimmer.Swim();   
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // PROGRAM TESTING 
            Console.WriteLine("\n-------Programming Challenge #1-------\n");

            // create one instance of each animal 
            Dog myDog = new Dog{Name = "Henry", Age = 14};
            Fish myFish = new Fish{Name = "Bubbles", Age = 2};
            Duck myDuck = new Duck{Name = "Pibble", Age = 5};

            // add animals to the zoo
            Zoo myZoo = new Zoo();  // create zoo object
            myZoo.AddAnimal(myDog);
            myZoo.AddAnimal(myFish);
            myZoo.AddAnimal(myDuck);

            // call behaviors through base-class reference 
            myZoo.MakeAllAnimalsSound();
            myZoo.ShowRunningAnimals();
            myZoo.ShowSwimmingAnimals();
        }
    }
} // end of program
