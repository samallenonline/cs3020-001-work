/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #2

The objective of this program is to gain practice 
with using LINQ to manipulate and perform various
operations on data, as well as review classes and 
objects in C#.

PART 5: Aggregating Data with LINQ
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace PartFive
{
    public class Transaction
    {
        /*
        This class represents a transaction object, 
        and holds information such as the transaction 
        ID, the amount of the transcation, and the date
        in which it occured.
        */

        // public properties
        public int TransactionId {get; set;}
        public decimal Amount {get; set;}
        public DateTime Date {get; set;}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nPart 5. Aggregating Data with LINQ\n");

            // create a list of transactions and initialize properties
            var transactions = new List<Transaction>
            {
                new Transaction{TransactionId = 1, Amount = 100, Date = DateTime.Now.AddDays(-5)},
                new Transaction{TransactionId = 2, Amount = 200, Date = DateTime.Now.AddDays(-10)},
                new Transaction{TransactionId = 3, Amount = 300, Date = DateTime.Now.AddDays(-40)},
                new Transaction{TransactionId = 4, Amount = 50, Date = DateTime.Now.AddDays(-20)}
            };

            /*
            write a LINQ query that 
                - sums the total amount of transactions that occured 
                in the last 30 days
                - assumes today's date is the current system date
            */
            var last30Days = DateTime.Now.AddDays(-30);
            var result = transactions
                .Where(t => t.Date >= last30Days)
                .Sum(t => t.Amount);

            // print results of the query
            Console.WriteLine($"Total amount of transactions in the last 30 days: {result:C}\n");
        }
    }
} // end of namespace PartFive
