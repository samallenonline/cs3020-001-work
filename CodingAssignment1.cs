/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Assignment #1

This program will model a simple student and course 
management system using abstract classes, interfaces,
and LINQ. 
*/

using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Person {
    /*
    This class represents a person
    */

    // declare properties 
    public required string FirstName {get; set;}
    public required string LastName {get; set;}
    public int Age {get; set;}

    // declare methods 
    public string GetFullName() {
        /*
        This method returns the full name of the 
        student as a string
        */
        return($"{FirstName} {LastName}");
    }
}

public interface IEnrollable {
    /*
    This interface provides a blueprint for those 
    who are capable of being enrolled in a course
    */

    // method that enrolls a person in a specified course 
    void EnrollInCourse(Course course);
}

public class Student : Person, IEnrollable {
    /*
    This class represents a student
    */
    // public properties
    public List<Course> EnrolledCourses{get; private set;} = new List<Course>();

    public void EnrollInCourse(Course course) {
        /*
        This method enrolls a student in a specified course 
        */
        EnrolledCourses.Add(course);
    }
}

public class Course
{
    /*
    This class represents a course in which students
    can enroll themselves in
    */

    // public properties 
    public required string CourseName {get; set;}
    public int Credits {get; set;}
}

public class CourseManagementSystem
{
    /*
    This class represents a course management system 
    for a school, allowing students to enroll in courses
    and keeping track of students and available courses
    */
    // private properties
    private List<Course> courses = new List<Course>();
    private List<Student> students = new List<Student>();

    public void AddCourse (Course course)
    {
        /*
        This method adds a course to the course 
        management system
        */
        courses.Add(course);
    }

    public void AddStudent (Student student)
    {
        /*
        This method adds a student to the course 
        management system
        */
        students.Add(student);
    }

    public IEnumerable<Student> GetStudentsEnrolledInCourse (string courseName)
    {
        /*
        runs a LINQ query and returns the result 
        for students who are enrolled in the specified course 
        */

        // check if students list is empty 
        if (!students.Any()) {
            return Enumerable.Empty<Student>();
        }

        IEnumerable<Student> filteringQuery =
            from s in students 
            from course in s.EnrolledCourses
            where course.CourseName == courseName
            select s;

        return filteringQuery.Distinct(); // remove duplicates
    }

    public double GetAverageCreditsEnrolledByStudents ()
    {
        /* 
        runs a LINQ query to find the average sum of credits that 
        students are enrolled in and returns the result
        */

        // check if students list is empty 
        if (!students.Any()) {
            return 0;
        }
 
        // if not empty, continue to calculate average
        var averageCredits =
        (from s in students 
        select s.EnrolledCourses.Sum(c => c.Credits))
        .Average(); 

        return averageCredits;

    }
}

// main program 
class Program
{
    static void Main()
    {
        Console.WriteLine("\n\n----------Coding Assignment #1----------");
        Console.WriteLine("\nBEFORE ENROLLMENT:\n");

        // create courses 
        Course math101 = new Course{CourseName = "Math 101", Credits = 3};
        Course cs101 = new Course{CourseName = "CS 101", Credits = 4};
        Course history101 = new Course{CourseName = "History 101", Credits = 3};

        // create students 
        Student student1 = new Student{FirstName = "John", LastName = "Doe", Age = 20};
        Student student2 = new Student{FirstName = "Jane", LastName = "Smith", Age = 22};
        Student student3 = new Student{FirstName = "Alice", LastName = "Brown", Age = 21};
        
        // create course management system 
        CourseManagementSystem cms = new CourseManagementSystem();

        // use query to obtain students enrolled in "CS 101" course 
        var studentsInCS101_1 = cms.GetStudentsEnrolledInCourse("CS 101");
        Console.WriteLine("Students enrolled in CS 101: ");
        if (!studentsInCS101_1.Any()) {
            Console.WriteLine("> There are no students currently enrolled in this course");
        }
        else {
            foreach (var student in studentsInCS101_1) {
                Console.WriteLine(student.GetFullName());
            }    
        }

        // use query to obtain students enrolled in "History 101" course
        var studentsInHistory101_1 = cms.GetStudentsEnrolledInCourse("History 101");
        Console.WriteLine("\nStudents enrolled in History 101: ");
        if (!studentsInHistory101_1.Any()) {
            Console.WriteLine("> There are no students currently enrolled in this course");
        }
        else {
            foreach (var student in studentsInHistory101_1) {
                Console.WriteLine(student.GetFullName());
            }    
        }

        // use query to obtain students enrolled in "Math 101" course
        var studentsInMath101_1 = cms.GetStudentsEnrolledInCourse("Math 101");
        Console.WriteLine("\nStudents enrolled in Math 101: ");
        if (!studentsInMath101_1.Any()) {
            Console.WriteLine("> There are no students currently enrolled in this course");
        }
        else {
            foreach (var student in studentsInMath101_1) {
                Console.WriteLine(student.GetFullName());
            }    
        }

        // use query to obtain the average credits per student 
        var averageCredits1 = cms.GetAverageCreditsEnrolledByStudents();
        if (averageCredits1 == 0) {
            Console.WriteLine("\nAverage credits per student: 0");
            Console.WriteLine("> There are no students currently enrolled\n");
        }
        else {
            Console.WriteLine($"\nAverage credits per student: {averageCredits1:F2}\n");
        }

        Console.WriteLine("AFTER ENROLLMENT:\n");

        // enroll students in courses
        student1.EnrollInCourse(math101);
        student1.EnrollInCourse(cs101);

        student2.EnrollInCourse(cs101);
        student2.EnrollInCourse(history101);

        student3.EnrollInCourse(math101);
        student3.EnrollInCourse(history101);

        // enroll students in courses
        cms.AddCourse(math101);
        cms.AddCourse(cs101);
        cms.AddCourse(history101);

        cms.AddStudent(student1);
        cms.AddStudent(student2);
        cms.AddStudent(student3);

        // use query to obtain students enrolled in "CS 101" course 
        var studentsInCS101_2 = cms.GetStudentsEnrolledInCourse("CS 101");
        Console.WriteLine("Students enrolled in CS 101: ");
        if (!studentsInCS101_2.Any()) {
            Console.WriteLine("> There are no students currently enrolled in this course");
        }
        else {
            foreach (var student in studentsInCS101_2) {
                Console.WriteLine(student.GetFullName());
            }    
        }

        // use query to obtain students enrolled in "History 101" course
        var studentsInHistory101_2 = cms.GetStudentsEnrolledInCourse("History 101");
        Console.WriteLine("\nStudents enrolled in History 101: ");
        if (!studentsInHistory101_2.Any()) {
            Console.WriteLine("> There are no students currently enrolled in this course");
        }
        else {
            foreach (var student in studentsInHistory101_2) {
                Console.WriteLine(student.GetFullName());
            }    
        }

        // use query to obtain students enrolled in "Math 101" course
        var studentsInMath101_2 = cms.GetStudentsEnrolledInCourse("Math 101");
        Console.WriteLine("\nStudents enrolled in Math 101: ");
        if (!studentsInMath101_2.Any()) {
            Console.WriteLine("> There are no students currently enrolled in this course");
        }
        else {
            foreach (var student in studentsInMath101_2) {
                Console.WriteLine(student.GetFullName());
            }    
        }

        // use query to obtain the average credits per student 
        var averageCredits2 = cms.GetAverageCreditsEnrolledByStudents();
        if (averageCredits2 == 0) {
            Console.WriteLine("\nAverage credits per student: 0");
            Console.WriteLine("> There are no students currently enrolled\n");
        }
        else {
            Console.WriteLine($"\nAverage credits per student: {averageCredits2:F2}\n");
        }
    
    }
}