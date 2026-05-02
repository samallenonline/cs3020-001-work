using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        /* simulated list of work items */
        var data = new List<int>();
        for (int i = 0; i < 20; i++)
        {
            data.Add(10_000 + i * 500); /* difficult comptation */
        }

        var stopwatch = Stopwatch.StartNew();

        /* will absolutely be on final exam */
        Parallel.ForEach(data, i =>
        {
            int primes = CountPrimes(i);
            // Console.WriteLine($"Prime count: {primes}");
            Console.WriteLine($"Found {primes} primes up to {i} on thread {Thread.CurrentThread.ManagedThreadId}");
        });

        stopwatch.Stop();
        Console.WriteLine($"All tasks completed in {stopwatch.ElapsedMilliseconds} ms");
    }

    /* simulate CPU-intensive work */
    static int CountPrimes(int n)
    {
        int count = 0;
        for (int i = 2; i <=n; i++)
        {
            if (IsPrime(i)) count ++;
        }
        return count;
    }

    /* determine if number is prime */
    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}