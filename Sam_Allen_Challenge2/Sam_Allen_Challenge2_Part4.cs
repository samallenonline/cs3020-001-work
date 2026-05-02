/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #2

The objective of this program is to gain practice 
with using LINQ to manipulate and perform various
operations on data, as well as review classes and 
objects in C#.

PART 4: Projecting Data with LINQ
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace PartFour
{
    public class Student
    /*
    This class represents a student object, and 
    holds information such as the student's name,
    what subject they are taking, and their grade.
    */

    // public properties
    {
        public string Name {get; set;}
        public string Subject {get; set;}
        public int Grade {get; set;}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nPart 4. Projecting Data with LINQ\n");

            // create a list of students and initialize properties
            var students = new List<Student>
            {
                new Student{Name = "Mike", Subject = "Math", Grade = 85},
                new Student{Name = "Emma", Subject = "English", Grade = 90},
                new Student{Name = "Liam", Subject = "Math", Grade = 78},
                new Student{Name = "Sophia", Subject = "Science", Grade = 88}
            };

            /*
            write a LINQ query that 
                - projects the students' names and their subjects into an anonymous type
                - filters out students who have a grade lower than 80
            */
            var result = students
                .Where(s => s.Grade >= 80)
                .Select(s => new{s.Name, s.Subject})
                .ToList();

            // print results of the query
            foreach(var item in result)
            {
                Console.WriteLine($"Name: {item.Name}, Subject: {item.Subject}");
            }
            Console.WriteLine("\n");
        }
    }
} // end of namespace PartFour