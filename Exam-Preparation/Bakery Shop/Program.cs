using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakery_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<double> waterDozes = new Queue<double>(Console.ReadLine().Split().Select(double.Parse));
            Stack<double> flourDozes = new Stack<double>(Console.ReadLine().Split().Select(double.Parse));
            Dictionary<string, int> bakedProducts = new Dictionary<string, int>();
            while (waterDozes.Count > 0 && flourDozes.Count > 0)
            {
                double waterAmount = waterDozes.Dequeue();
                double flourAmount = flourDozes.Pop();
                double waterRatio = (waterAmount * 100) / (waterAmount + flourAmount);
                double flourRatio = (flourAmount * 100) / (waterAmount + flourAmount);
                string backedProduct = null;
                if (waterRatio == 40 && flourRatio == 60)       //•Muffin – consists of 40 % water and 60 % flour
                {
                    backedProduct = "Muffin";
                }
                else if (waterRatio == 30 && flourRatio == 70)  //•	Baguette – consists of 30 % water and 70 % flour
                {
                    backedProduct = "Baguette";
                }
                else if (waterRatio == 20 && flourRatio == 80)  //•	Bagel – consists of 20 % water and 80 % flour
                {
                    backedProduct = "Bagel";
                }
                else                                           //•	Croissant – consists of 50 % water and 50 % flour
                {
                    if (flourAmount > waterAmount)
                    {
                        backedProduct = "Croissant";
                        flourAmount -= waterAmount;
                        flourDozes.Push(flourAmount);
                    }
                    else
                    {
                        backedProduct = "Croissant";
                    }
                }
                if (bakedProducts.ContainsKey(backedProduct))
                {
                    bakedProducts[backedProduct] += 1;
                }
                else
                {
                    bakedProducts.Add(backedProduct, 1);
                }
            }
            bakedProducts = bakedProducts
                      .OrderByDescending(x => x.Value)
                      .ThenBy(y => y.Key)
                      .ToDictionary(x => x.Key, y => y.Value);
            foreach (var product in bakedProducts)
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }
            if (waterDozes.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: " + string.Join(", ", waterDozes));
            }
            if (flourDozes.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: " + string.Join(", ", flourDozes));
            }
        }
    }
}
