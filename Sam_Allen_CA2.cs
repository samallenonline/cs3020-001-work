/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Assignment #2

Objective: Process a list of integers in parallel
and compute their squares. Support cancellation 
when the user presses any key.
*/

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        /* define a list of integers to process */
        List<int> numbers = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        /* create cancellation token */
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken c_token = cts.Token;

        /* start a background task to listen for key press */
        Task.Run(() =>
        {
            Console.WriteLine("Starting list processing...");

            /* wait for ENTER key press before cancelling*/
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("Press the ENTER key to cancel...");
            }

            Console.WriteLine("\nENTER key pressed... cancelling processing");
            cts.Cancel();
        });

        /* wrap parallel processing in a try-catch block */
        try
        {
            /* start processing numbers */
            await ProcessNumbersAsync(numbers, c_token);
        }
        catch(OperationCanceledException)
        {
            Console.WriteLine("Processing cancelled by user.");
        }
    }

    /* method which processes numbers asynchronously */
    static async Task ProcessNumbersAsync(List<int> numbers, CancellationToken token)
    {
        await Task.Run(() =>
        {
            Parallel.ForEach(numbers, new ParallelOptions{CancellationToken = token}, number =>
            {
                Console.WriteLine($"{number} is being processed...");
                Thread.Sleep(1000); /* simulate work, wait 1 second */

                /* check if cancellation is requested */
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine($"Operation cancelled before processing {number}...");
                    return;
                }

                /* compute and print square of number */
                Console.WriteLine($"Square of {number} is {number * number}");
            });
        });
    }
}