using System;
using System.Linq;

namespace _3._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToArray();

            Func<int[], int> minNum = x => x.Min();
            Console.WriteLine(minNum(numbers));
        }
    }
}
