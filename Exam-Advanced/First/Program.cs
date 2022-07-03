using System;
using System.Collections.Generic;
using System.Linq;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whites = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> greys = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Dictionary<string, int> locations = new Dictionary<string, int>();
            while (whites.Count > 0 && greys.Count > 0)
            {
                int whiteCurr = whites.Pop();
                int greyCurr = greys.Dequeue();
                string spot = null;
                if (whiteCurr == greyCurr)
                {
                    if (whiteCurr + greyCurr == 70)//Wall
                    {
                        spot = "Wall";
                    }
                    else if (whiteCurr + greyCurr == 60)//Countertop
                    {
                        spot = "Countertop";
                    }
                    else if (whiteCurr + greyCurr == 50)
                    {
                        spot = "Oven";
                    }
                    else if (whiteCurr + greyCurr == 40)
                    {
                        spot = "Sink";
                    }
                    else
                    {
                        spot = "Floor";
                    }
                    if (locations.ContainsKey(spot))
                    {
                        locations[spot] += 1;
                    }
                    else
                    {
                        locations.Add(spot, 1);
                    }
                }
                else
                {
                    whiteCurr = whiteCurr / 2;
                    whites.Push(whiteCurr);
                    greys.Enqueue(greyCurr);
                }
            }
            if (whites.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whites)}");
            }
            if (greys.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greys)}");
            }
            locations = locations.OrderByDescending(x => x.Value).ThenBy(y => y.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var spot in locations)
            {
                Console.WriteLine($"{spot.Key}: {spot.Value}");
            }
        }
    }
}
