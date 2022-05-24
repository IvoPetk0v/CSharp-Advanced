using System;
using System.Linq;

namespace _2.__2X2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToArray();
            char[,] matrix = new char[matrixSize[0], matrixSize[1]];
            ReadMatrixDataFromConsole(matrix);
            int squresMatrixes = 0;
            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    if (matrix[rows, cols] == matrix[rows, cols + 1] &&
                        matrix[rows + 1, cols] == matrix[rows + 1, cols + 1] &&
                        matrix[rows, cols] == matrix[rows + 1, cols])
                    {
                        squresMatrixes++;
                    }
                }
            }
            Console.WriteLine(squresMatrixes);
        }
        static char[,] ReadMatrixDataFromConsole(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] chars = Console.ReadLine()
                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                      .Select(char.Parse)
                      .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = chars[cols];
                }
            }
            return matrix;
        }
    }
}
