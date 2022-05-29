using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputColor = Console.ReadLine()
                  .Split(" -> ")
                  .ToArray();
                string[] inputClothes = inputColor[1].Split(",").ToArray();
                if (!wardrobe.ContainsKey(inputColor[0]))
                {
                    Dictionary<string, int> currClothes = new Dictionary<string, int>();
                    for (int j = 0; j < inputClothes.Length; j++)
                    {
                        if (!currClothes.ContainsKey(inputClothes[j]))
                        {
                            currClothes.Add(inputClothes[j], 1);
                        }
                        else
                        {
                            currClothes[inputClothes[j]] += 1;
                        }
                    }
                    wardrobe.Add(inputColor[0], currClothes);
                }
                else
                {
                    Dictionary<string, int> currClothes = new Dictionary<string, int>();
                    currClothes = wardrobe[inputColor[0]];
                    for (int j = 0; j < inputClothes.Length; j++)
                    {
                        if (currClothes.ContainsKey(inputClothes[j]))
                        {
                            currClothes[inputClothes[j]] += 1;
                        }
                        else
                        {
                            currClothes.Add(inputClothes[j], 1);
                        }
                    }
                    wardrobe[inputColor[0]] = currClothes;
                }
            }
            string[] searchCloth = Console.ReadLine()
                .Split(" ")
                .ToArray();
            foreach (var clothes in wardrobe)
            {
                Console.WriteLine($"{clothes.Key} clothes:");
                if (searchCloth[0] == clothes.Key)
                {
                    foreach (var cloth in clothes.Value)
                    {
                        if (searchCloth[1] == cloth.Key)
                        {
                            Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                        }
                    }
                }
                else
                {
                    foreach (var cloth in clothes.Value)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
