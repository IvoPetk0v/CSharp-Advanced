using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Predicate_Party_
{
    class Program
    {
        static void RemovingGuest(List<string> guestList, string[] cmds)
        {
            if (cmds[1] == "StartsWith")
            {
                guestList.RemoveAll(guest => guest.StartsWith(cmds[2]));
            }
            else if (cmds[1] == "EndsWith")
            {
                guestList.RemoveAll(guest => guest.EndsWith(cmds[2]));
            }
            else if (cmds[1] == "Length")
            {
                guestList.RemoveAll(guest => guest.Length == int.Parse(cmds[2]));
            }
        }
        static void DoubleTheGuest(List<string> guestList, string[] cmds)
        {
            if (cmds[1] == "StartsWith")
            {
                for (int i = 0; i < guestList.Count; i++)
                {
                    if (guestList[i].StartsWith(cmds[2]))
                    {
                        guestList.Insert(i, guestList[i]);
                        i++;
                    }
                }
            }
            else if (cmds[1] == "EndsWith")
            {
                for (int i = 0; i < guestList.Count; i++)
                {
                    if (guestList[i].EndsWith(cmds[2]))
                    {
                        guestList.Insert(i, guestList[i]);
                        i++;
                    }
                }
            }
            else if (cmds[1] == "Length")
            {
                for (int i = 0; i < guestList.Count; i++)
                {
                    if (guestList[i].Length == (int.Parse(cmds[2])))
                    {
                        guestList.Insert(i, guestList[i]);
                        i++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            List<string> guestList = Console.ReadLine().Split().ToList();
            string input;

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] cmds = input
                  .Split(" ")
                  .ToArray();

                if (cmds[0] == "Remove")
                {
                    RemovingGuest(guestList, cmds);
                }
                else if (cmds[0] == "Double")
                {
                    DoubleTheGuest(guestList, cmds);
                }
            }
            if (guestList.Count==0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.Write(String.Join(", ",guestList));
                Console.Write(" are going to the party!");
            }
        }
    }
}
