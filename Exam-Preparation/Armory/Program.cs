using System;
using System.Collections.Generic;
using System.Linq;

namespace Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            ReadMatrixDataFromConsole(matrix);
            List<int> swords = new List<int>();
            int sumOfSwords = swords.Sum();
            while (sumOfSwords <= 65)
            {
                char spotItem;

                int[] officer = OfficerOnField(matrix);
                matrix[officer[0], officer[1]] = '-';
                string move = Console.ReadLine().TrimEnd().TrimStart();
                if (move == "up")
                {
                    if (IsInRangeOfMatrix(matrix, officer[0] - 1, officer[1]))
                    {
                        matrix[officer[0], officer[1]] = '-';
                        spotItem = matrix[officer[0] - 1, officer[1]];
                        if (isItMirror(matrix, spotItem, swords))
                        {
                            matrix[officer[0] - 1, officer[1]] = '-';
                            officer = MirrorTravel(matrix);
                            matrix[officer[0], officer[1]] = 'A';
                        }
                        else
                            matrix[officer[0] - 1, officer[1]] = 'A';
                    }
                    else
                    {
                        break;
                    }
                }
                else if (move == "down")
                {
                    if (IsInRangeOfMatrix(matrix, officer[0] + 1, officer[1]))
                    {
                        matrix[officer[0], officer[1]] = '-';
                        spotItem = matrix[officer[0] + 1, officer[1]];
                        if (isItMirror(matrix, spotItem, swords))
                        {
                            matrix[officer[0] + 1, officer[1]] = '-';
                            officer = MirrorTravel(matrix);
                            matrix[officer[0], officer[1]] = 'A';
                        }
                        else
                            matrix[officer[0] + 1, officer[1]] = 'A';
                    }
                    else
                    {
                        break;
                    }
                }
                else if (move == "left")
                {
                    if (IsInRangeOfMatrix(matrix, officer[0], officer[1] - 1))
                    {
                        matrix[officer[0], officer[1]] = '-';
                        spotItem = matrix[officer[0], officer[1] - 1];
                        if (isItMirror(matrix, spotItem, swords))
                        {
                            matrix[officer[0], officer[1] - 1] = '-';
                            officer = MirrorTravel(matrix);
                            matrix[officer[0], officer[1]] = 'A';
                        }
                        else
                            matrix[officer[0], officer[1] - 1] = 'A';
                    }
                    else
                    {
                        break;
                    }
                }
                else if (move == "right")
                {
                    if (IsInRangeOfMatrix(matrix, officer[0], officer[1] + 1))
                    {
                        matrix[officer[0], officer[1]] = '-';
                        spotItem = matrix[officer[0], officer[1] + 1];
                        if (isItMirror(matrix, spotItem, swords))
                        {
                            matrix[officer[0], officer[1] + 1] = '-';
                            officer = MirrorTravel(matrix);
                            matrix[officer[0], officer[1]] = 'A';
                        }
                        else
                            matrix[officer[0], officer[1] + 1] = 'A';
                    }
                    else
                    {
                        break;
                    }
                }
                sumOfSwords = swords.Sum();
            }
            if (sumOfSwords >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
                Console.WriteLine($"The king paid {sumOfSwords} gold coins. ");
            }
            else
            {
                Console.WriteLine("I do not need more swords!");
                Console.WriteLine($"The king paid {sumOfSwords} gold coins. ");
            }
            PrintMatrix(matrix);
        }
        static char[,] ReadMatrixDataFromConsole(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] numbers = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = numbers[cols];
                }
            }
            return matrix;
        }
        static int[] OfficerOnField(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] == 'A')
                    {
                        int[] officerCoordinates = new int[2] { rows, cols };
                        return officerCoordinates;
                    }
                }
            }
            return null;
        }
        static int[] MirrorTravel(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] == 'M')
                    {
                        int[] mirrorCoordinates = new int[2] { rows, cols };
                        return mirrorCoordinates;
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
            return false;
        }
        static bool isItMirror(char[,] matrix, char spotItem, List<int> swords)
        {
            if (char.IsDigit(spotItem) || spotItem == '-')
            {
                if (char.IsDigit(spotItem))
                {
                    swords.Add(spotItem - 48); // ASCII
                }
                return false;
            }
            return true;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols] + "");
                }
                Console.WriteLine();
            }
        }
    }
}
