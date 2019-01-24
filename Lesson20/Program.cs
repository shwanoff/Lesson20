using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson20
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            // Домашнее задание
            // В вашей предметной области реализовать работу с коллекциями данных
            // с помощью LINQ. Попробовать все операции

            var products = new List<Product>();
            for(var i = 0; i < 10; i++)
            {
                var product = new Product()
                {
                    Name = "Продукт" + i,
                    Energy = rnd.Next(10, 12)
                };
                products.Add(product);
            }

            var result = from item in products
                         where item.Energy < -700
                         select item;

            var result2 = products.Where(item => item.Energy < 200 || item.Energy > 400);
            
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            var selectCollection = products.Select(product => product.Energy);
            foreach (var item in selectCollection)
            {
                Console.WriteLine(item);
            }

            var orderbyCollection = products.OrderBy(product => product.Energy)
                                            .ThenByDescending(product => product.Name);
            foreach (var item in orderbyCollection)
            {
                Console.WriteLine(item);
            }

            var groupbyCollection = products.GroupBy(product => product.Energy);
            foreach(var group in groupbyCollection)
            {
                Console.WriteLine($"Ключ: {group.Key}");
                foreach(var item in group)
                {
                    Console.WriteLine($"\t{item}");
                }
                Console.WriteLine();
            }

            products.Reverse();
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(products.All(item => item.Energy == 10));
            Console.WriteLine(products.Any(item => item.Energy == 10));
            var prod = new Product();
            Console.WriteLine(products.Contains(prod));
            var array = new int[] { 1, 2, 3, 4 };
            var array2 = new int[] { 3, 4, 5, 6 };
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            var union = array.Union(array2);
            foreach (var item in union)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var intersect = array.Intersect(array2);
            foreach (var item in intersect)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var except = array2.Except(array);
            foreach (var item in except)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var sum = array.Sum();
            var min = products.Min(p => p.Energy);
            var max = products.Max(p => p.Energy);
            var aggregate = array.Aggregate((x, y) => x * y);

            var sum2 = array.Skip(1).Take(2).Sum();

            var first = products.First(product => product.Energy == 10);
            var last = array.LastOrDefault();
            var single = products.Single(product => product.Energy == 10);
            var elementAt = products.ElementAt(5);

            Console.ReadLine();
        }
    }
}
