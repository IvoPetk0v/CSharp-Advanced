using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder strBuilder = new StringBuilder();
            Stack<string> previousStateOfString = new Stack<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] cmdArgs = input
                         .Split(" ")
                         .ToArray();

                if (int.Parse(cmdArgs[0]) == 1)    //appends string to the end
                {
                    string substring = cmdArgs[1];
                    previousStateOfString.Push(strBuilder.ToString());
                    strBuilder.Append(substring);
                }
                else if (int.Parse(cmdArgs[0]) == 2) // erase last n chars
                {
                    int countOfChars = int.Parse(cmdArgs[1]);
                    previousStateOfString.Push(strBuilder.ToString());
                    EraseSubstring(strBuilder, countOfChars);
                }
                else if (int.Parse(cmdArgs[0]) == 3)   // return ch on pointed index
                {
                    int index = int.Parse(cmdArgs[1]) - 1;
                    Console.WriteLine(strBuilder[index]);
                }
                else if (int.Parse(cmdArgs[0]) == 4) // undo last cmds type 1 or 2 
                {
                    if (previousStateOfString.Count > 0)
                    {
                        if (strBuilder.ToString() != previousStateOfString.Peek())
                        {
                            strBuilder = new StringBuilder(previousStateOfString.Peek());
                        }
                        else
                        {
                            previousStateOfString.Pop();
                            strBuilder = new StringBuilder(previousStateOfString.Peek());
                        }
                    }
                }
            }

        }
        static void EraseSubstring(StringBuilder strBuilder, int removalCount)
        {
            if (strBuilder.Length > removalCount)
            {
                strBuilder.Remove(strBuilder.Length - removalCount, removalCount);
            }
            else
            {
                strBuilder.Clear();
            }
        }
    }
}
