using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeMatrix, sizeMatrix];
            matrix = ReadMatrixDataFromConsole(matrix);
            int sumFirstDiag = 0;
            int sumSecondDiag = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (rows == cols)
                    {
                        sumFirstDiag += matrix[rows, cols];
                    }
                    if (rows == matrix.GetLength(0) - cols - 1)
                    {
                        sumSecondDiag += matrix[rows, cols];
                    }
                }
            }
            Console.WriteLine(Math.Abs(sumSecondDiag - sumFirstDiag));
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

    }
}
