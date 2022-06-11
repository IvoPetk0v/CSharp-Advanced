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
                string input = Console.ReadLine();
                Box<string> box = new Box<string>(input);
                Console.WriteLine(box);
            }
        }
    }
}
