using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] arguments = input
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int n = arguments[0]; // number of elements to push in stack 
            int s = arguments[1]; // number of pops from stack
            int x = arguments[2]; // number to look for 

            input = Console.ReadLine();
            int[] numbers = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }
            if (stack.Count >= s)
            {
                for (int i = 0; i < s; i++)
                {
                    stack.Pop();
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }

        }
    }
}
