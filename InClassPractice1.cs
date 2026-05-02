/*
Practice using delegates 
*/

using System;

public class Program {
    // delcare the delegate tyoe 
    public delegate int Calculation(int a, int b);

    // methods that share delegate signature
    public static int Add(int a, int b) {
        return a + b;
    }
    
    public static int Multiply(int a, int b) {
        return a * b;
    }

    public static void Main() {
        // instantiate the delegate and point it to Add and Multiply 
        Calculation calculation = new Calculation(Add);
        Console.WriteLine($"Add: {calculation(5,3)}");

        calculation = new Calculation(Multiply);
        Console.WriteLine($"Multiply: {calculation(5,3)}");
    }
}