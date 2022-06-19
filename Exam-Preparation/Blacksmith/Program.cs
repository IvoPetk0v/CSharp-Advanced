using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            //const int gladius = 70, shamshir = 80, katana = 90, sabre = 110, broadsword = 150;

            Queue<int> steals = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> carbons = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Dictionary<string, int> swordsCost = new Dictionary<string, int> {
            { "Gladius",70},
            { "Shamshir", 80},
            { "Katana", 90},
            { "Sabre", 110},
            { "Broadsword", 150 }
        };

            SortedDictionary<string, int> swords = new SortedDictionary<string, int>();
            while (true)
            {
                int stealElement = steals.Dequeue();
                int carbonElement = carbons.Pop();
                string currentSword = null;
                foreach (var item in swordsCost)
                {
                    if (item.Value == stealElement + carbonElement)
                    {
                        currentSword = item.Key;
                    }
                }
                if (currentSword != null)
                {
                    if (!swords.ContainsKey(currentSword))
                    {
                        swords.Add(currentSword, 1);
                    }
                    else
                    {
                        swords[currentSword] += 1;
                    }
                }
                else
                {
                    carbonElement += 5;
                    carbons.Push(carbonElement);
                }
                if (carbons.Count == 0 || steals.Count == 0)
                {
                    break;
                }

            }
            if (swords.Count > 0)
            {
                Console.WriteLine($"You have forged {swords.Sum(x => x.Value)} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steals.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else // steals.Count > 0 
            {

                Console.WriteLine("Steel left: " + String.Join(", ", steals));
            }
            if (carbons.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine("Carbon left: " + String.Join(", ", carbons));
            }
            foreach (var sword in swords)
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}

