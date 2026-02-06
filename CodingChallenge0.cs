/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #0

This program demonstrates concepts we have learned in 
class thus far, including: in, out, and ref parameters, 
automatic get/set properties, and reading user input from 
the console.
*/

using System;
using System.Security.Principal;
using Microsoft.VisualBasic;

class Program
{
    // example method using the 'in' parameter (cannot be modified inside)
    static void ShowSquare(in int number)
    {
        Console.WriteLine($"Square of {number} is {number * number}");
    }

    // example method using 'out' parameter (must assign value inside)
    static void GetUserFullName(out string fullName)
    {
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        fullName = firstName + " " + lastName; // combine names
    }

    // example method using 'ref' parameter (modifies caller's variables)
    static void AddBonus(ref int score, int bonus)
    {
        score += bonus; // add bonus to score
        Console.WriteLine($"Score after bonus: {score}");
    }

    // a simple class with automatic get/set properities
    class Student
    {
        public string Name {get; set;}
        public int Age {get; set;}
    }

    static void Main(string[] args)
    {
        // demonstrate 'in'
        Console.Write("Enter a number to square: ");
        int num = int.Parse(Console.ReadLine());
        ShowSquare(in num);

        // demonstrate 'out'
        GetUserFullName(out string fullName);
        Console.WriteLine($"Hello, {fullName}");

        // demonstrate 'ref'
        Console.Write("Enter your score: ");
        int score = int.Parse(Console.ReadLine());
        AddBonus(ref score, 10);

        // demonstrate automatic get/set
        Student student = new Student();
        Console.Write("Enter student's name: ");
        student.Name = Console.ReadLine();
        Console.Write("Enter student's age: ");
        student.Age = int.Parse(Console.ReadLine());

        Console.WriteLine($"Student Info: Name = {student.Name}, Age = {student.Age}");
    }
}