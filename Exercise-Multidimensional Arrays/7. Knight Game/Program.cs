using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int countKnightsToWithdraw = 0;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine().TrimEnd().ToUpper();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            while (true)
            {
                int maxHits = 0;
                int[] coordinatesForBurn = new int[2];
                for (int rows = 0; rows < n; rows++)
                {
                    for (int cols = 0; cols < n; cols++)
                    {
                        char currentSpot = matrix[rows, cols];
                        if (currentSpot == 'K')
                        {
                            int knightsHits = HowManyKnightsHits(matrix, rows, cols);
                            if (knightsHits > 0 && knightsHits > maxHits)
                            {
                                maxHits = knightsHits;
                                coordinatesForBurn[0] = rows;
                                coordinatesForBurn[1] = cols;
                            }
                        }
                    }
                }
                if (maxHits == 0)
                {
                    break;
                }
                else
                {
                    matrix[coordinatesForBurn[0], coordinatesForBurn[1]] = '0';
                    countKnightsToWithdraw++;
                }
            }
            Console.WriteLine(countKnightsToWithdraw);
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
        static int HowManyKnightsHits(char[,] matrix, int row, int col)
        {
            int knightsHits = 0;

            if (IsInRangeOfMatrix(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
            {
                knightsHits++;
            }
            if (IsInRangeOfMatrix(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
            {
                knightsHits++;
            }
            if (IsInRangeOfMatrix(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
            {
                knightsHits++;
            }
            if (IsInRangeOfMatrix(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
            {
                knightsHits++;
            }
            if (IsInRangeOfMatrix(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
            {
                knightsHits++;
            }
            if (IsInRangeOfMatrix(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
            {
                knightsHits++;
            }
            if (IsInRangeOfMatrix(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
            {
                knightsHits++;
            }
            if (IsInRangeOfMatrix(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
            {
                knightsHits++;
            }

            return knightsHits;
        }
    }
}
