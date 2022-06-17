using System;
using System.Collections.Generic;
using System.Linq;

namespace Beaver_at_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            matrix = ReadMatrixDataFromConsole(matrix);
            string cmd;
            int neededBranchs = BranchesInMatrix(matrix);
            List<char> branchs = new List<char>();
            while ((cmd = Console.ReadLine()) != "end" && branchs.Count != neededBranchs)
            {
                char spotItem;
                if (cmd == "down")
                {
                    int[] beaver = BeaverOnField(matrix);
                    if (IsInRangeOfMatrix(matrix, beaver[0] + 1, beaver[1]))
                    {
                        matrix[beaver[0], beaver[1]] = '-';
                        spotItem = matrix[beaver[0] + 1, beaver[1]];
                        if (spotItem == 'F')
                        {
                            matrix[beaver[0] + 1, beaver[1]] = '-';
                            beaver[0] += 1;
                            if (beaver[0] != matrix.GetLength(0) - 1)
                            {
                                beaver[0] += 1;
                            }
                            else // -1 ?? 
                            {
                                beaver[0] = 0;
                            }
                            spotItem = matrix[beaver[0], beaver[1]];
                            CheckForBranch(matrix, spotItem, branchs);
                            matrix[beaver[0], beaver[1]] = 'B';
                            continue;
                        }
                        else
                        {
                            CheckForBranch(matrix, spotItem, branchs);
                            matrix[beaver[0] + 1, beaver[1]] = 'B';
                            continue;
                        }
                    }
                    else
                    {
                        if (branchs.Count > 0)
                        {
                            branchs.RemoveAt(branchs.Count - 1);
                            neededBranchs--;
                        }
                    }
                }
                else if (cmd == "up")
                {
                    int[] beaver = BeaverOnField(matrix);
                    if (IsInRangeOfMatrix(matrix, beaver[0] - 1, beaver[1]))
                    {
                        matrix[beaver[0], beaver[1]] = '-';
                        spotItem = matrix[beaver[0] - 1, beaver[1]];
                        if (spotItem == 'F')
                        {
                            matrix[beaver[0] - 1, beaver[1]] = '-';
                            beaver[0] -= 1; // ok
                            if (beaver[0] != 0)  // -1 ?? 
                            {
                                beaver[0] -= 1;
                            }
                            else
                            {
                                beaver[0] = matrix.GetLength(0) - 1;
                            }
                            spotItem = matrix[beaver[0], beaver[1]];
                            CheckForBranch(matrix, spotItem, branchs);
                            matrix[beaver[0], beaver[1]] = 'B';
                            continue;
                        }
                        else
                        {
                            CheckForBranch(matrix, spotItem, branchs);
                            matrix[beaver[0] - 1, beaver[1]] = 'B';
                            continue;
                        }
                    }
                    else
                    {
                        if (branchs.Count > 0)
                        {
                            neededBranchs--;
                            branchs.RemoveAt(branchs.Count - 1);
                        }
                    }
                }
                else if (cmd == "left")
                {
                    int[] beaver = BeaverOnField(matrix);
                    if (IsInRangeOfMatrix(matrix, beaver[0], beaver[1] - 1))
                    {
                        matrix[beaver[0], beaver[1]] = '-';
                        spotItem = matrix[beaver[0], beaver[1] - 1];
                        if (spotItem == 'F')
                        {
                            matrix[beaver[0], beaver[1] - 1] = '-';
                            beaver[1] -= 1;
                            if (beaver[1] != 0)
                            {
                                beaver[1] -= 1;
                            }
                            else // -1 ?? 
                            {
                                beaver[1] = matrix.GetLength(1) - 1;
                            }
                            spotItem = matrix[beaver[0], beaver[1]];
                            CheckForBranch(matrix, spotItem, branchs);
                            matrix[beaver[0], beaver[1]] = 'B';
                            continue;
                        }
                        else
                        {
                            CheckForBranch(matrix, spotItem, branchs);
                            matrix[beaver[0], beaver[1] - 1] = 'B';
                            continue;
                        }
                    }
                    else
                    {
                        if (branchs.Count > 0)
                        {
                            neededBranchs--;
                            branchs.RemoveAt(branchs.Count - 1);
                        }
                    }
                }
                else if (cmd == "right")
                {
                    int[] beaver = BeaverOnField(matrix);
                    if (IsInRangeOfMatrix(matrix, beaver[0], beaver[1] + 1))
                    {
                        matrix[beaver[0], beaver[1]] = '-';
                        spotItem = matrix[beaver[0], beaver[1] + 1];
                        if (spotItem == 'F')
                        {
                            matrix[beaver[0], beaver[1] + 1] = '-';
                            beaver[1] += 1;
                            if (beaver[1] != matrix.GetLength(1) - 1)
                            {
                                beaver[1] += 1;
                            }
                            else
                            {
                                beaver[1] = 0;
                            }
                            spotItem = matrix[beaver[0], beaver[1]];
                            CheckForBranch(matrix, spotItem, branchs);
                            matrix[beaver[0], beaver[1]] = 'B';
                            continue;
                        }
                        else
                        {
                            CheckForBranch(matrix, spotItem, branchs);
                            matrix[beaver[0], beaver[1] + 1] = 'B';
                            continue;
                        }
                    }
                    else
                    {
                        if (branchs.Count > 0)
                        {
                            neededBranchs--;
                            branchs.RemoveAt(branchs.Count - 1);
                        }
                    }
                }
            }
            if (neededBranchs == branchs.Count)
            {
                Console.Write($"The Beaver successfully collect {branchs.Count} wood branches: ");
                Console.WriteLine(String.Join(", ", branchs) + ".");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {neededBranchs - branchs.Count} branches left.");
            }
            PrintMatrix(matrix);
        }
        static char[,] ReadMatrixDataFromConsole(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] numbers = Console.ReadLine()
                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                      .Select(char.Parse)
                      .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = numbers[cols];
                }
            }
            return matrix;
        }
        static int[] BeaverOnField(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] == 'B')
                    {
                        int[] beaverCoordinates = new int[2] { rows, cols };
                        return beaverCoordinates;
                    }
                }
            }
            return null;
        }
        static bool IsInRangeOfMatrix(char[,] matrix, int row, int col)
        {
            if (row < matrix.GetLength(0) && col < matrix.GetLength(1) && row >= 0 && col >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void CheckForBranch(char[,] matrix, char spotItem, List<char> branchs)
        {
            if (char.IsLower(spotItem))
            {
                branchs.Add(spotItem);
                return;
            }

        }
        static int BranchesInMatrix(char[,] matrix)
        {
            int branches = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (char.IsLower(matrix[row, col]))
                    {
                        branches++;
                    }
                }
            }
            return branches;
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
