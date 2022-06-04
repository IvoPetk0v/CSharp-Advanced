using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guestList = Console.ReadLine()
                   .Split()
                   .ToList();
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();
            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] cmds = input
                .Split(";")
                .ToArray();

                if (cmds[0] == "Add filter")
                {
                    Predicate<string> predicate = GetPredicate(cmds);
                    filters.Add(cmds[2], predicate);
                }
                else if (cmds[0] == "Remove filter")
                {
                    Predicate<string> predicate = GetPredicate(cmds);
                    filters.Remove(cmds[2]);
                }
            }
            foreach (var filter in filters)
            {
                guestList.RemoveAll(filter.Value);
            }
            Console.WriteLine(String.Join(" ", guestList));
        }
        private static Predicate<string> GetPredicate(string[] cmds)
        {
            if (cmds[1] == "Starts with")
            {
                return name => name.StartsWith(cmds[2]);
            }
            else if (cmds[1] == "Ends with")
            {
                return name => name.EndsWith(cmds[2]);
            }
            else if (cmds[1] == "Length")
            {
                return name => name.Length == int.Parse(cmds[2]);
            }
            else if (cmds[1] == "Contains")
            {
                return name => name.Contains(cmds[2]);
            }
            return null;
        }
    }
}
