using System;
using System.Collections.Generic;
using System.Linq;

namespace Truffle_Hunter
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            char[,] matrix = new char[sizeMatrix, sizeMatrix];
            ReadMatrixDataFromConsole(matrix);
            // B=> black W=>white S => summer L=> whiteBoar
            Dictionary<char, int> truffs = new Dictionary<char, int> { { 'B', 0 }, { 'W', 0 }, { 'S', 0 }, { 'L', 0 } };
            string input;
            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                int row, col;
                bool whiteBoar = false;
                string[] cmds = input.Split().ToArray();
                if (cmds[0] == "Collect")
                {
                    row = int.Parse(cmds[1]);
                    col = int.Parse(cmds[2]);
                    if (IsInRangeOfMatrix(matrix, row, col))
                    {
                        CheckForTruff(matrix, row, col, truffs, whiteBoar);
                    }
                }
                else if (cmds[0] == "Wild_Boar")
                {
                    row = int.Parse(cmds[1]);
                    col = int.Parse(cmds[2]);
                    string direction = cmds[3];
                    whiteBoar = true;
                    MoveWhiteBoar(matrix, row, col, direction, truffs, whiteBoar);
                }
            }
            Console.WriteLine($"Peter manages to harvest {truffs['B']} black, {truffs['S']} summer, and {truffs['W']} white truffles.");
            Console.WriteLine($"The wild boar has eaten {truffs['L']} truffles.");
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
        static void CheckForTruff(char[,] matrix, int row, int col, Dictionary<char, int> truffs, bool whiteBoar)
        {
            if (matrix[row, col] != '-' && !whiteBoar)
            {
                truffs[matrix[row, col]] += 1;
                matrix[row, col] = '-';
            }
            else if (matrix[row, col] != '-' && whiteBoar)
            {
                truffs['L'] += 1;
                matrix[row, col] = '-';
            }

        }
        static void MoveWhiteBoar(char[,] matrix, int row, int col, string direction, Dictionary<char, int> truffs, bool whiteBoar)
        {
            if (direction == "up")
            {

                for (int rows = row; rows >= 0; rows--)
                {
                    CheckForTruff(matrix, rows, col, truffs, whiteBoar);
                    rows--;
                }
            }
            else if (direction == "down")
            {
                for (int rows = row; rows < matrix.GetLength(0); rows++)
                {
                    CheckForTruff(matrix, rows, col, truffs, whiteBoar);
                    rows++;
                }
            }
            else if (direction == "left")
            {
                for (int cols = col; cols >= 0; cols--)
                {
                    CheckForTruff(matrix, row, cols, truffs, whiteBoar);
                    cols--;
                }
            }
            else if (direction == "right")
            {
                for (int cols = col; cols < matrix.GetLength(1); cols++)
                {
                    CheckForTruff(matrix, row, cols, truffs, whiteBoar);
                    cols++;
                }
            }
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
