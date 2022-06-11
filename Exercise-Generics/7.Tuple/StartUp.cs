using System;
using System.Linq;

namespace Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            {
                string names = input[0] + " " + input[1];
                string address = input[2];
                var tupleOne = new Tuple<string, string>(names, address);
                Console.WriteLine(tupleOne);
            }
            input = Console.ReadLine().Split().ToArray();
            string name = input[0];
            int beerCount = int.Parse(input[1]);
            var tupleTwo = new Tuple<string, int>(name, beerCount);
            Console.WriteLine(tupleTwo);

            input = Console.ReadLine().Split().ToArray();
            int numOne = int.Parse(input[0]);
            double numTwo = double.Parse(input[1]);
            var tupleTree = new Tuple<int, double>(numOne, numTwo);
            Console.WriteLine(tupleTree);

        }
    }
}
