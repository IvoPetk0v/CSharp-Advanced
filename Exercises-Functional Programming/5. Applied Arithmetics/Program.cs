using System;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToArray();
            string input;
            Action<int[]> printNums = numbers => Console.WriteLine(String.Join(" ", numbers));
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "add")
                {
                    numbers = numbers.Select(x => x = x + 1).ToArray();
                }
                else if (input == "multiply")
                {
                    numbers = numbers.Select(x => x = x * 2).ToArray();
                }
                else if (input == "subtract")
                {
                    numbers = numbers.Select(x => x = x - 1).ToArray();
                }
                else if (input == "print")
                {
                    printNums(numbers);
                }
            }
        }
    }
}
