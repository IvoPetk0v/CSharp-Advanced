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
            var list = new List<string>();
            for (int i = 0; i < numOfInputs; i++)
            {
                string input = Console.ReadLine();
                list.Add(input);
            }
            var box = new Box<string>(list);
            var cmd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.SwapElements(list, cmd[0], cmd[1]);
            Console.WriteLine(box);
        }
    }
}
