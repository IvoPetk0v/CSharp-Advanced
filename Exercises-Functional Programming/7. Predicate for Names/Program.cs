using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            Predicate<string> rightLenghtChars = word => word.Length <= n;
            names = names.Where(x => rightLenghtChars(x)).ToList();
            Console.WriteLine(String.Join(Environment.NewLine, names));
        }
    }
}
