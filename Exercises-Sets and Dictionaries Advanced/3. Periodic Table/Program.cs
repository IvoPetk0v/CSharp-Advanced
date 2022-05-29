using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> chemicals = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] array = Console.ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();
                for (int j = 0; j < array.Length; j++)
                {
                    chemicals.Add(array[j]);
                }
            }
            Console.WriteLine(String.Join(" ", chemicals));
        }
    }
}
