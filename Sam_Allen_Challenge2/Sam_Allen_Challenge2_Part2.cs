/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #2

The objective of this program is to gain practice 
with using LINQ to manipulate and perform various
operations on data, as well as review classes and 
objects in C#.

PART 2: Grouping Data with LINQ
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace PartTwo
{
    public class Product
    {
        /*
        This class represents a product object, and holds 
        information such as the product category and 
        price.
        */

        // public properties
        public string Category {get;set;}
        public decimal Price {get;set;}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nPart 2. Grouping Data with LINQ\n");

            // create a list of products in inventory
            var products = new List<Product>
            {
                new Product{Category = "Electronics", Price = 199.99M},
                new Product{Category = "Electronics", Price = 50.00M},
                new Product{Category = "Clothing", Price = 29.99M},
                new Product{Category = "Clothing", Price = 79.99M},
                new Product{Category = "Electronics", Price = 120.00M}
            };

            /*
            write a LINQ query that
                - groups products by their category 
                - calculates the total price for each group 
                - returns the category name along with the total price 
                of products in that category
            */
            var result = products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    TotalPrice = g.Sum(p => p.Price)
                })
                .ToList();

            // print results of the query
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Category}: {item.TotalPrice:C}");
            }
            Console.WriteLine("\n");
        }
    }
} // end of namespace PartTwo