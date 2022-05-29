using System;
using System.Collections.Generic;

namespace _5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> charsOccurre = new SortedDictionary<char, int>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char currCh = input[i];
                if (charsOccurre.ContainsKey(currCh))
                {
                    charsOccurre[currCh] += 1;
                }
                else
                {
                    charsOccurre.Add(currCh, 1);
                }
            }
            foreach (var item in charsOccurre)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
