using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToArray();
            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
            int[,] bestMatrix3x3 = new int[3, 3];
            int sumBestMatrixElements = 0;

            matrix = ReadMatrixDataFromConsole(matrix);

            for (int rows = 0; rows <= matrix.GetLength(0) - 3; rows++)
            {
                for (int cols = 0; cols <= matrix.GetLength(1) - 3; cols++)
                {
                    int currentSum = 0;
                    currentSum += matrix[rows, cols]     + matrix[rows, cols + 1]     + matrix[rows, cols + 2];
                    currentSum += matrix[rows + 1, cols] + matrix[rows + 1, cols + 1] + matrix[rows + 1, cols + 2];
                    currentSum += matrix[rows + 2, cols] + matrix[rows + 2, cols + 1] + matrix[rows + 2, cols + 2];

                    if (sumBestMatrixElements < currentSum)
                    {
                        sumBestMatrixElements = currentSum;
                        bestMatrix3x3 = new int[3, 3]
                        {
                           {matrix[rows, cols] ,     matrix[rows, cols + 1] ,     matrix[rows, cols + 2] },
                           {matrix[rows + 1, cols] , matrix[rows + 1, cols + 1] , matrix[rows + 1, cols + 2]},
                           {matrix[rows + 2, cols] , matrix[rows + 2, cols + 1] , matrix[rows + 2, cols + 2]}
                        };
                    }
                }
            }
            Console.WriteLine($"Sum = {sumBestMatrixElements}");
            PrintMatrix(bestMatrix3x3);

        }
        static int[,] ReadMatrixDataFromConsole(int[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] numbers = Console.ReadLine()
                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = numbers[cols];
                }
            }
            return matrix;
        }
        static void PrintMatrix(int[,] matrix)
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
