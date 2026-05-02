/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #6 - Question #1

Objective: Process a list of integers using 
Parallel.ForEach with cancellation support.
*/

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        /* boolean to check if cancelled
        (added this so print statements are accurate) */
        bool isCancelled = false;
        var items = new List<int>();
        for (int i = 0; i < 100; i++) items.Add(i);

        /* create cancellation token */
        CancellationTokenSource cts = new CancellationTokenSource();

        /* create task to process numbers and run */
        Task processTask = Task.Run(() =>
        {
            try
            {
                /* configure settings for ParallelOptions */
                var options = new ParallelOptions()
                {
                    CancellationToken = cts.Token
                };

                /* process each item */
                Parallel.ForEach(items, options, item =>
                {
                    Console.WriteLine($"Processing item {item}.");
                    Thread.Sleep(200); /* simulate work */
                });
            }
            catch (OperationCanceledException)
            {
                isCancelled = true;
                Console.WriteLine("Operation was cancelled.");
            }
            if (!isCancelled) Console.WriteLine("Completed processing.");  
        });

        /* cancel after 1 second has passed */
        cts.CancelAfter(1000);
        Console.WriteLine("User requested cancellation.");

        processTask.Wait();
    }
}