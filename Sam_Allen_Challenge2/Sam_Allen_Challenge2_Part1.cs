/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #2

The objective of this program is to gain practice 
with using LINQ to manipulate and perform various
operations on data, as well as review classes and 
objects in C#.

PART 1: Filtering and Sorting with LINQ
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace PartOne
{
    public class Employee
    {
        /*
        This class represents an employee object, and holds 
        information such as the employee's name, age, and 
        the department they work in
        */

        // public properties
        public string Name {get; set;}
        public int Age {get; set;}
        public string Department {get; set;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nPart 1: Filtering and Sorting with LINQ\n");

            // create a list of employees who work at a given company
            var employees = new List<Employee>
            {
                new Employee{Name = "John", Age = 29, Department = "HR"},
                new Employee{Name = "Sara", Age = 22, Department = "IT"},
                new Employee{Name = "Alice", Age = 35, Department = "Finance"},
                new Employee{Name = "Bob", Age = 28, Department = "Marketing"},
                new Employee{Name = "Eve", Age = 40, Department = "IT"}
            };

            /*
            write a LINQ query that 
                - filters out employees younger than 25 years old
                - sorts the remaining employees by age in descending order 
                - selects only the name and department 
            */
            var result = employees
                .Where(e => e.Age >=25)
                .OrderByDescending(e => e.Age)
                .Select(e => new{e.Name, e.Department})
                .ToList();

            // print results of the query
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name}, {item.Department}");
            }
            Console.WriteLine("\n");
        }
    }
} // end of namespace PartOne
