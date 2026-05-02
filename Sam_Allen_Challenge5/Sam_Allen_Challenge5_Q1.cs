/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #5 - Question #1

Objective: Build a console application that simulates 
a long-running task. The operation should be cancelable
by the user pressing the Enter key at any time during 
execution.
*/

using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    /* simulates a long-running task that checks for cancellation */
    static async Task RunWorkAsync(CancellationToken token)
    {
        Console.WriteLine("Work started...\n");
        
        for (int i = 1; i <= 10; i++)
        {
            /* check if cancellation was requested */
            token.ThrowIfCancellationRequested();

            /* simulate each step of task */
            Console.WriteLine($"Step {i}/10 in progress...");
            await Task.Delay(1000, token); 
        }
        Console.WriteLine("\nWork completed successfully.");
    }

    static async Task Main(string[] args)
    {
        using CancellationTokenSource cts = new CancellationTokenSource();
        Console.WriteLine("Press ENTER at any time to cancel the operation. \n");

        /* start the long-running task with token */
        Task workTask = RunWorkAsync(cts.Token);

        /* wait for either the Enter key or the work to complete */
        Task cancelTask = Task.Run(() => Console.ReadLine());
        Task finishedTask = await Task.WhenAny(workTask, cancelTask);

        /* if Enter pressed first, cancel operation */
        if (finishedTask == cancelTask)
        {
            cts.Cancel();
            Console.WriteLine("Cancellation requested by user.");
        }

        /* await the work task to observe any exceptions */
        try
        {
            await workTask;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\nOperation was cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nUnexpected error: {ex.Message}");
        }

        Console.WriteLine("\nProgram has ended. Press any key to exit.");
        Console.ReadKey();
    }
}