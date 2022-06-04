using System;
using System.Linq;

namespace _2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Select(x => x = "Sir " + x).ToArray();
            Action<string> print = message => Console.WriteLine(message);
            foreach (var word in input)
            {
                print(word);
            }
        }
    }
}
