using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] deviders = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int devider = 0;
            int number = 0;
            Predicate<int> opa = number => number % devider == 0;
            
            var resultNum = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                bool isDevideable = true;
                for (int j = 0; j < deviders.Length; j++)
                {
                    number = i;
                    devider = deviders[j];
                    if (!opa(number))
                    {
                        isDevideable = false;
                        break;
                    }
                    
                }
                if (isDevideable)
                {
                    resultNum.Add(i);
                }
            }
            Console.WriteLine(String.Join(" ", resultNum));

        }
    }
}
