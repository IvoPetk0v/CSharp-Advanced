using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));
            while (songs.Count > 0)
            {
                string input = Console.ReadLine();
                string[] cmds = input
                .Split(" ")
                .ToArray();
                if (cmds[0] == "Play")
                {
                    songs.Dequeue();
                }
                else if (cmds[0] == "Add")
                {
                    string songName = string.Join(" ", cmds.Skip(1));
                    if (!songs.Contains(songName))
                    {
                        songs.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                }
                else if (cmds[0] == "Show")
                {
                    Console.WriteLine(String.Join(", ", songs));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
