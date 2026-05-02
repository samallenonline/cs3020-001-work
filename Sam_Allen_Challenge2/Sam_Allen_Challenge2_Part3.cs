/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #2

The objective of this program is to gain practice 
with using LINQ to manipulate and perform various
operations on data, as well as review classes and 
objects in C#.

PART 3: Joining Data with LINQ
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace PartThree
{
    public class Customer
    {
        /*
        This class represents a customer object, and 
        holds information such as the customer's ID and 
        their name.
        */
        // public properties
        public int CustomerId {get; set;}
        public string Name {get; set;}
    }

    public class Order
    {
        /*
        This class represents an customer's order, and 
        holds informaation such as the order ID, the 
        customer's ID, and the total cost of the order.
        */
        public int OrderId {get; set;}
        public int CustomerId {get; set;}
        public decimal Amount {get; set;}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nPart 3. Joining Data with LINQ\n");

            // create a list of customers and initialize properties
            var customers = new List<Customer>
            {
                new Customer{CustomerId = 1, Name = "John"},
                new Customer{CustomerId = 2, Name = "Sara"},
                new Customer{CustomerId = 3, Name = "Alice"}
            };

            // create a list of orders and initialize properties
            var orders = new List<Order>
            {
                new Order{OrderId = 101, CustomerId = 1, Amount = 250},
                new Order{OrderId = 102, CustomerId = 2, Amount = 450},
                new Order{OrderId = 103, CustomerId = 1, Amount = 300}
            };

            /*
            write a LINQ query that 
                - joins the Customer and Order lists based on the CustomerID
                - selects each customer's name, order ID, and amount 
                - returns a list of customers along with their order details
            */
            var result = customers
            .Join(orders, c => c.CustomerId, o => o.CustomerId, (c, o) => new
            {
                c.Name,
                o.OrderId,
                o.Amount
            })
            .ToList();

            // print results of the query
            foreach (var item in result)
            {
                Console.WriteLine($"Customer: {item.Name}, OrderId: {item.OrderId}, Amount: {item.Amount:C}");
            }
            Console.WriteLine("\n");
        }
    }
} // end of namespace PartThree