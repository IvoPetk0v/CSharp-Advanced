using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            int[] countOfSets = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < countOfSets[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < countOfSets[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }
            firstSet.IntersectWith(secondSet);
            Console.WriteLine(String.Join(" ", firstSet));
        }
    }
}
