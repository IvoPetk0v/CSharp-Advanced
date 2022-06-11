using System;
using System.Linq;

namespace Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            string names = input[0] + " " + input[1];
            string address = input[2];
            string town;
            if (input.Length > 4)
            {
                town = input[3] + " " + input[4];
            }
            else
            {
                town = input[3];
            }
            var threepleOne = new Threeuple<string, string, string>(names, address, town);
            Console.WriteLine(threepleOne);

            input = Console.ReadLine().Split().ToArray();
            string name = input[0];
            int beerCount = int.Parse(input[1]);
            bool drunk = Drunk(input[2]);
            var threepleTwo = new Threeuple<string, int, bool>(name, beerCount, drunk);
            Console.WriteLine(threepleTwo);

            input = Console.ReadLine().Split().ToArray();
            string firstName = input[0];
            double accBalace = double.Parse(input[1]);
            string bankName = input[2];
            var tupleTree = new Threeuple<string, double, string>(firstName, accBalace, bankName);
            Console.WriteLine(tupleTree);

        }
        public static bool Drunk(string state)
        {
            if (state == "drunk")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
