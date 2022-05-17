using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                if (array[0] == 1)
                {
                    int number = array[1];
                    stack.Push(number);
                }
                else if (array[0] == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (array[0] == 3 && stack.Count>0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (array[0] == 4 && stack.Count>0)
                {
                    Console.WriteLine(stack.Min());
                }
            }
            if (stack.Count > 0)
            {
                Console.WriteLine(string.Join(", ", stack));
            }
            
        }
    }
}
