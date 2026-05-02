/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #4 - Question #1

Objective: Create a program that processes 
user data and performs some background tasks
asynchronously.
*/

using System;
using System.Threading.Tasks;

public class User
{
    /* this class represents a single user, 
    including information such as name and age */
    public string Name {get; set;}
    public int Age {get; set;}
}

public class AsyncExample
{
    public async Task DownloadDataAsync()
    {
        /* simulate the data download */
        Console.WriteLine("> Starting data download...");
        await Task.Delay(2000);
        Console.WriteLine("> Data download completed.");
    }

    public async Task<User> GetUserDetailsAsync(int userID)
    {
        /* obtain user information for the given user */
        Console.WriteLine($"> Fetching details for user {userID}...");
        await Task.Delay(1000);

        return new User {Name = "Sam Allen", Age = 21};
    }

    public async Task ButtonClickHandlerAsync(object sender, EventArgs e)
    {
        /* simulate a button click */
        Console.WriteLine("> Button clicked, starting async operation...");
        await Task.Delay(1000);
        Console.WriteLine("> Button click operation completed.");
    }
}
public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("\nTask 1: Async Method Return Types\n");

        /* create instance of AsyncExample */
        AsyncExample myExample = new AsyncExample();
        await myExample.DownloadDataAsync();
        var user = await myExample.GetUserDetailsAsync(1);

        /* print user details */
        Console.WriteLine($"User Details: Name = {user.Name}, Age = {user.Age}");

        /* simulate a button click */
        await myExample.ButtonClickHandlerAsync(null, EventArgs.Empty);
        await Task.Delay(2000);
    }
}