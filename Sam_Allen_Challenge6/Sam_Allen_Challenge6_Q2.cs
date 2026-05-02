/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #6 - Question #2

Objective: Compute factorials of large numbers 
in parallel and support cancellation.
*/

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        /* boolean to check if cancelled
        (added this so print statements are accurate) */
        bool isCancelled = false;
        /* these numbers produce an outrageously large result so here is 
        a list of reasonable ones */
        // var numbers = new List<int> {100, 120, 150, 130};
        var numbers = new List<int> {10000, 12000, 15000, 13000};
        CancellationTokenSource cts = new CancellationTokenSource();

        /* configure settings for ParallelOptions */
        var options = new ParallelOptions()
        {
            CancellationToken = cts.Token
        };

        /* create task to process tasks and run */ 
        Task factorialTask = Task.Run(() =>
        {
            try
            {
                Parallel.ForEach(numbers, options, number =>
                {
                    Console.WriteLine($"Calculating factorial of {number} on thread {Thread.CurrentThread.ManagedThreadId}");
                    BigInteger result = CalculateFactorial(number, cts.Token);
                    Console.WriteLine($"Factorial of {number} = {result}");
                });
            }
            catch (OperationCanceledException)
            {
                isCancelled = true;
                Console.WriteLine("Factorial operation was cancelled.");
            }    
            if (!isCancelled) Console.WriteLine("Completed processing.");        
        });

        /* cancel after 2 seconds has passed */
        cts.CancelAfter(2000);
        Console.WriteLine("User requested cancellation.");

        factorialTask.Wait();
    }

    /* method which calculates factorial of a given big integer using loops */
    static BigInteger CalculateFactorial(int n, CancellationToken token)
    {
        BigInteger result = 1;

        /* cannot calculate factorials of negative numbers */ 
        if (n < 0)
        {
            throw new ArgumentException("Cannot compute factorial for negative numbers");
        }

        /* calculate factorial */
        for (int i = 1; i <= n; i++) 
        {
            token.ThrowIfCancellationRequested();
            result *= i;
        }
        return result;
    }

    /*
    method which calculates the factorial of any large integer recursively 
    RESULTS IN STACK OVERFLOW - DO NOT USE 

    static BigInteger CalculateFactorial(int n, CancellationToken token)
    {
        if (n >= 1) n is greater than 1 
        {
            return n*CalculateFactorial(n-1, token);
        }
        else
        {
            return 1;
        }
    }
    */
}
