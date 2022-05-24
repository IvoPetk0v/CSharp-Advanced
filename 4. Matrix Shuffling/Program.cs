using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();
            string[,] matrix = new string[matrixSize[0], matrixSize[1]];
            matrix = ReadMatrixDataFromConsole(matrix);
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input
                .Split(" ")
                .ToArray();
                if (cmdArgs[0] == "swap")
                {
                    if (cmdArgs.Length == 5)
                    {
                        if (IsInRangeOfMatrix(matrix, int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2])) &&
                            IsInRangeOfMatrix(matrix, int.Parse(cmdArgs[3]), int.Parse(cmdArgs[4])))
                        {
                            matrix = SwapMatrixElementsPrintResult(matrix, cmdArgs);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
        static string[,] ReadMatrixDataFromConsole(string[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string[] numbers = Console.ReadLine()
                      .Split(" ")
                      .ToArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = numbers[cols];
                }
            }
            return matrix;
        }
        static string[,] SwapMatrixElementsPrintResult(string[,] matrix, string[] cmdArgs)
        {
            string firstElement = matrix[int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2])];    // element[row,col]
            string secondElement = matrix[int.Parse(cmdArgs[3]), int.Parse(cmdArgs[4])];  //  element[row,col]
            matrix[int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2])] = secondElement;
            matrix[int.Parse(cmdArgs[3]), int.Parse(cmdArgs[4])] = firstElement;
            PrintMatrix(matrix);
            return matrix;
        }
        static void PrintMatrix(string[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (rows == matrix.GetLength(0) - 1 && cols == matrix.GetLength(1) - 1)
                    {
                        Console.Write(matrix[rows, cols]);

                    }
                    else
                    {
                        Console.Write(matrix[rows, cols] + " ");
                    }

                }
                Console.WriteLine();
            }
        }
        static bool IsInRangeOfMatrix(string[,] matrix, int row, int col)
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
    }
}
