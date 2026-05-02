/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #4 - Question #3

Objective: Write a program that finds prime 
numbers asynchronously up to a limit.
*/

/* 
Note: The CPU bound task will not become 
faster because async programming is used, it is 
only used to keep the rest of the program responsive
while the heavy async CPU bound work is in progress.
*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AsyncCPUExample
{
    public async Task FindPrimesAsync(int max)
    {
        /* finds all primes up to a given limit 
        and prints these primes */
        Console.WriteLine("> Starting prime number calculation...");
        var myPrimes = await Task.Run(() => FindPrimes(max));
        
        foreach (var prime in myPrimes) {
            Console.WriteLine(prime);
        }
    }

    private List<int> FindPrimes(int max)
    {
        /* finds all primes up to a given limit 
        and returns a list of these primes */

        List<int> primesList = new List<int> {};
        /* check for primes up to the given limit */
        for (int i = 0; i < max + 1; i++) {
            // Console.WriteLine($"Checking {i}...");
            if (IsPrime(i)) {
                primesList.Add(i);
            }
        }
        return primesList;
    }

    private bool IsPrime(int number)
    {
        /* returns true if the number is prime, 
        returns false if the number is not prime */

        double sqrtNumber = System.Math.Sqrt(number);
        /* prime numbers are natural number greater than 1
        and only divisible by 1 and themselves */
        if (number > 1) {
            for (int i = 2; i <= sqrtNumber; i++) {
                if ((number % i) == 0) {
                    /* divisible by a number other than itself, 
                    not prime */
                    return false;
                }
            }
            return true;
        }
        /* less than 1, not prime */
        else return false; 
    }

    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("\nTask 3: Async CPU-Bound Task\n");

            // create instance of AsyncCPUExample
            AsyncCPUExample myAsyncCPU = new AsyncCPUExample();
            await myAsyncCPU.FindPrimesAsync(1000);
        }
    }
}