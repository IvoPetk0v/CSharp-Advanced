using System;
using System.Collections.Generic;
using System.Linq;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfInputs = int.Parse(Console.ReadLine());
            var list = new List<double>();
            for (int i = 0; i < numOfInputs; i++)
            {
                double input = double.Parse(Console.ReadLine());
                list.Add(input);
            }
            var box = new Box<double>(list);
            double elementToCompare = double.Parse(Console.ReadLine());
            int count = box.CountGreaterThanElements(list, elementToCompare);
            Console.WriteLine(count);
        }
    }
}
