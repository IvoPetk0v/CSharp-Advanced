using System;
using System.Collections.Generic;

namespace _4._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                if (numbers.ContainsKey(currNum))
                {
                    numbers[currNum] += 1;
                }
                else
                {
                    numbers.Add(currNum, 1);
                }
            }
            foreach (var num in numbers)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                    break;
                }
            }
        }
    }
}
