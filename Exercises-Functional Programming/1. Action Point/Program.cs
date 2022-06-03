using System;
using System.Linq;

namespace _1._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            Action<string> print = message => Console.WriteLine(message);
            foreach (var word in input)
            {
                print(word);
            }

        }

    }
}
