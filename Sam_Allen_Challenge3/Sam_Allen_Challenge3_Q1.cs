/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #3 - Question #1

Objective: Design a system for managing different types of 
vehicles  that can start and stop. Implement an abstract 
class and two interfaces that describe vehicle behavior.
*/

using System;

namespace VehicleManagement
{
    public abstract class Vehicle
    {
        /* 
        This abstract class represents a single vehicle.
        */
        public string Name {get; set;}

        public Vehicle(string name)
        {
            Name = name;
        }
    
        public void DisplayVehicleInfo()
        {
            /* 
            This method displays the name of the vehicle.
            */
            Console.WriteLine($"Vehicle: {Name}");
        }
    }

    public interface IStartable
    {
        /*
        This interface should be implemented for 
        entities which are startable.
        */
        void Start();
        bool IsRunning {get; set;}
    }

    public interface IStoppable
    {
        /*
        This interface should be implemented for 
        entities which are stoppable.
        */
        void Stop();
        bool IsStopped {get; set;}
    }

    public class Car: Vehicle, IStartable, IStoppable
    {
        /*
        This class represents a single car which is 
        capable of starting and stopping. 
        */

        public Car (string name): base(name) {}

        // properties
        public bool IsStopped {get; set;}
        public bool IsRunning{get; set;}

        public void Start()
        {
            /*
            This method will start the car.
            */
            IsRunning = true;
            IsStopped = false;
            Console.WriteLine($"{Name} has started.");
        }

        public void Stop()
        {
            /*
            This method will stop the car
            */
            IsRunning = false;
            IsStopped = true;
            Console.WriteLine($"{Name} has stopped.");
        }
    }

    public class Motorcycle: Vehicle, IStartable, IStoppable
    {
        /*
        This class represents a single motorcycle which is
        capable of starting and stopping.
        */ 

        public Motorcycle (string name): base(name) {}

        // properties
        public bool IsRunning {get; set;}
        public bool IsStopped {get; set;}

        public void Start()
        {
            IsRunning = true;
            IsStopped = false;
            Console.WriteLine($"{Name} has started.");
        }

        public void Stop()
        {
            IsRunning = false;
            IsStopped = true;
            Console.WriteLine($"{Name} has stopped.");
        }
    }

    // main program 
    class Program
    {
        static void Main(string[]args)
        {
            Console.WriteLine("\nTASK 1:\n");
            
            // create instances of Car and Motorcycle 
            var myCar = new Car("Volkswagen Beetle");
            var myMotorcycle = new Motorcycle("Yamaha MT-07");

            // test start/stop behavior
            myCar.DisplayVehicleInfo();
            myCar.Start();
            myCar.Stop();

            myMotorcycle.DisplayVehicleInfo();
            myMotorcycle.Start();
            myMotorcycle.Stop();
        }
    }
}