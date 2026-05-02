/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #4 - Question #2

Objective: Create a program that reads a large 
text file asynchronously using StreamReader.
*/

using System;
using System.IO;
using System.Threading.Tasks;

public class AsyncIOExample
{
    public async Task ReadFileAsync(string filePath)
    {
        /* reads a file at the specified file path 
        and prints the first 100 characters */
        Console.WriteLine("> Starting to read file...");

        using (StreamReader reader = new StreamReader(filePath))
        {
            string fileContents = await reader.ReadToEndAsync();
            Console.WriteLine("> Printing first 100 characters...");
            Console.WriteLine(fileContents.Substring(0, 100));
        }
    }
}

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("\nTask 2: Async I/O Operations\n");

        /* create an instance of AsyncIOExample */
        AsyncIOExample myExample = new AsyncIOExample();

        /* read file asynchronously */
        string filePath = "sample.txt";
        // string filePath = "Sam_Allen_Challenge4/sample.txt";
        await myExample.ReadFileAsync(filePath);
    }
}