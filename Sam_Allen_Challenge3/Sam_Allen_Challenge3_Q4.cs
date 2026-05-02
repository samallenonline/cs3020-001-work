/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #3 - Question #4

Objective: Implement a simple calculator using delegates 
to switch between operations.
*/

using System;

namespace DelegateCalculator
{
    // define delegate 
    public delegate int OperationHandler(int a, int b);

    public class Calculator
    {
        /*
        This class represents a simple calculator 
        and is intended to be used with delegates.
        */ 

        public static int Add(int a, int b)
        {
            /*
            This method adds two values together 
            and returns the result.
            */ 
            return a + b;
        }

        public static int Multiply (int a, int b)
        {
            /*
            This method multiplies two values together
            and returns the result.
            */
            return a * b;
        }
    }

    class Program
    {
        static void Main(string [] args)
        {
            Console.WriteLine("\nTASK 4:\n");

            // create delegate instances pointing to the Add() and Multiply() functions
            OperationHandler addOp = new OperationHandler(Calculator.Add);
            OperationHandler multiplyOp = new OperationHandler(Calculator.Multiply);

            // test various cases using delegate
            Console.WriteLine(addOp(8, 2));
            Console.WriteLine(multiplyOp(5, 5));
            Console.WriteLine(addOp(0, 3));
            Console.WriteLine(multiplyOp(0, 3));
        }
    }
}