using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            int capacityOfRack = int.Parse(Console.ReadLine());
            int racksCounter = 1;
            int clothesSum = 0;
            while (clothes.Count > 0)
            {
                if (capacityOfRack > clothesSum + clothes.Peek())
                {
                    clothesSum += clothes.Peek();
                    clothes.Pop();
                }
                else if (capacityOfRack == clothesSum + clothes.Peek())
                {
                    clothesSum += clothes.Peek();
                    clothes.Pop();
                }
                else
                {
                    racksCounter++;
                    clothesSum = 0;
                }
            }
            Console.WriteLine(racksCounter);
        }
    }
}
