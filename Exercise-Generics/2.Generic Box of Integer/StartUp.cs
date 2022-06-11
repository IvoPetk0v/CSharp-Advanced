using System;

namespace Box
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numOfInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfInputs; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }
    }
}
