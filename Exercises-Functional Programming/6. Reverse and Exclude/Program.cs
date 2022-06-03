using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                   .Split(" ")
                   .Select(int.Parse)
                   .ToArray();
            int devider = int.Parse(Console.ReadLine());
            Predicate<int> devidedNum = number => number % devider == 0;
            List<int> resultNums = numbers.ToList();
            foreach (var num in numbers)
            {
                if (devidedNum(num))
                {
                    resultNums.Remove(num);
                }
            }
            resultNums.Reverse();
            Console.WriteLine(String.Join(" ", resultNums));
        }
    }
}
