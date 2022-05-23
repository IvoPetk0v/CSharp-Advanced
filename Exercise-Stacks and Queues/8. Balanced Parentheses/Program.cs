using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> openBrackets = new Stack<char>();
            bool isBalanced = false;
            foreach (var ch in input)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    openBrackets.Push(ch);
                }
                else if (ch == ')' || ch == '}' || ch == ']')
                {
                    if (openBrackets.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    char lastOpen = openBrackets.Pop();
                    if (lastOpen == '(' && ch == ')')
                    {
                        isBalanced = true;
                    }
                    else if (lastOpen == '[' && ch == ']')
                    {
                        isBalanced = true;
                    }
                    else if (lastOpen == '{' && ch == '}')
                    {
                        isBalanced = true;
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
