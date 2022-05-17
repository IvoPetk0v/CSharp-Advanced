using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodSupply = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Console.WriteLine(orders.Max());
            while (orders.Count > 0)
            {
                if (orders.Peek() <= foodSupply)
                {
                    foodSupply -= orders.Peek();
                    orders.Dequeue();
                }
                else
                {
                    Console.Write($"Orders left: ");
                    Console.WriteLine(string.Join(" ", orders));
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
