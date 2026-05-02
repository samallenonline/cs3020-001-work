/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #3 - Question #2

Objective: Create a system to manage a collection 
of students. Some attributes (GPA, GraduationYear)
may be optional (nullable). Use a generic registry
class to store student objects. 
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentRegistrySystem
{
    public class Student
    {
        /*
        This class represents a single student, whose GPA
        and graduation year may be unknown.
        */
        public string Name {get; set;}
        public string Major {get; set;}

        public double? GPA {get; set;}
        public int? GraduationYear {get; set;}

        public Student (string name, string major, double? gpa = null, int? gradYear = null)
        {
            /*
            Constructor for a student object.
            */
            Name = name;
            Major = major;
            GPA = gpa;
            GraduationYear = gradYear;
        }

        public void DisplayStudentInfo()
        {
            /*
            This method displays all information about a student.
            */
            Console.WriteLine($"Name: {Name}, Major: {Major}");
            Console.WriteLine(GPA.HasValue ? $"GPA: {GPA}" : "GPA: N/A");
            Console.WriteLine(GraduationYear.HasValue ? $"Graduation Year: {GraduationYear}\n" : "Graduation Year: N/A\n");
        }
    }

    public class StudentRegistry<T> where T: Student
    {
        /*
        This class represents a generic student registry
        which manages several students.
        */

        //properties
        private List<T> students;

        public StudentRegistry()
        {
            students = new List<T>();
        }

        public void AddStudent(T student)
        {
            /*
            This method adds a specified student to the 
            student registry.
            */
            students.Add(student);
        }

        public IEnumerable<T> GetStudentsWithGPA()
        {
            /*
            This method returns all students who have 
            a documented GPA value.
            */

            var GPAStudents =
                from s in students
                where s.GPA.HasValue
                select s;

            return GPAStudents;
        }

        public IEnumerable<T> GetStudentsWithGraduationYear()
        {
            /*
            This method returns all students who have 
            a documented graduation year.
            */

            var gradYearStudents =
                from s in students 
                where s.GraduationYear.HasValue
                select s;

            return gradYearStudents;
        }

        public void DisplayAll()
        {
            /*
            This method displays student information for 
            all students in the registry.
            */

            if (students.Count == 0)
            {
                Console.WriteLine("There are no students in the registry.");          
            }
            else
            {
                for (int i = 0; i < students.Count; i++)
                {
                    students[i].DisplayStudentInfo();   
                }
            }
        }
    }

    // main program 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nTASK 2:\n");

            // create student registry 
            var myRegistry = new StudentRegistry<Student>();

            // test display method with no students
            myRegistry.DisplayAll();

            // create students and add them to registry 
            var myStudent1 = new Student("Sam", "CS", 3.9, 2026);
            var myStudent2 = new Student("Noah", "Bio");
            myRegistry.AddStudent(myStudent1);
            myRegistry.AddStudent(myStudent2);

            // test display method with students 
            Console.WriteLine("All students in registry:");
            myRegistry.DisplayAll();

            // display all students who have a GPA
            Console.WriteLine("All students who have GPA info:");
            var withGPA = myRegistry.GetStudentsWithGPA();
            foreach (var s in withGPA) s.DisplayStudentInfo();

            // display all students who have a graduation year
            Console.WriteLine("All students who have graduation year info:");
            var withGradYear = myRegistry.GetStudentsWithGraduationYear();
            foreach (var s in withGradYear) s.DisplayStudentInfo();

        }
    }
}