using System;
using System.Collections.Generic;
using System.Linq;

namespace Food_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().ToCharArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().ToCharArray());
            Dictionary<string, List<char>> words = new Dictionary<string, List<char>>
            {
                { "pear",new List<char>("pear".ToCharArray())   },
                { "flour",new List<char>("flour".ToCharArray()) },
                { "pork",new List<char>("pork".ToCharArray())   },
                { "olive",new List<char>("olive".ToCharArray()) }
            };
            while (consonants.Count > 0)
            {
                char vowel = vowels.Dequeue();
                char consonant = consonants.Pop();
                foreach (var word in words)
                {
                    if (word.Key.Contains(vowel))
                    {
                        word.Value.Remove(vowel);
                    }
                    if (word.Key.Contains(consonant))
                    {
                        word.Value.Remove(consonant);
                    }
                }
                vowels.Enqueue(vowel);
            }
            int countFoundWords = 0;

            foreach (var item in words)
            {
                if (item.Value.Count == 0)
                {
                    countFoundWords++;
                }
            }
            Console.WriteLine($"Words found: {countFoundWords}");
            foreach (var item in words)
            {
                if (item.Value.Count == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
