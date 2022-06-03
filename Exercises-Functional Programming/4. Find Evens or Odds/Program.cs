using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            List<int> numbers = new List<int>();
            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }
            string cmd = Console.ReadLine();
            Predicate<int> isEven = number => number % 2 == 0;
            if (cmd=="even")
            {
                numbers = numbers.Where(x => isEven(x)).ToList();
            }
            else
            {
                numbers = numbers.Where(x => !isEven(x)).ToList();
            }
            Console.WriteLine(String.Join(" ",numbers));
        }
    }
}
