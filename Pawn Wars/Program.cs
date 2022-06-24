using System;
using System.Linq;
using System.Text;

namespace Pawn_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[8, 8];
            ReadMatrixDataFromConsole(matrix);
            string[,] field = new string[8, 8];
            ReadMatrixField(field);

            while (true)
            {
                int[] whitePawn = WhitePawnOnField(matrix);
                int[] blackPawn = BlackPawnOnField(matrix);
                /// whitePawn move 
                if (IsInRangeOfMatrix(matrix, whitePawn[0] - 1, whitePawn[1] - 1) && matrix[whitePawn[0] - 1, whitePawn[1] - 1] == 'b')
                {
                    matrix[whitePawn[0], whitePawn[1]] = '-';
                    matrix[whitePawn[0] - 1, whitePawn[1] - 1] = 'w';
                    Console.WriteLine($"Game over! White capture on {field[whitePawn[0] - 1, whitePawn[1] - 1]}.");
                    break;
                }
                else if (IsInRangeOfMatrix(matrix, whitePawn[0] - 1, whitePawn[1] + 1) && matrix[whitePawn[0] - 1, whitePawn[1] + 1] == 'b')
                {
                    matrix[whitePawn[0], whitePawn[1]] = '-';
                    matrix[whitePawn[0] - 1, whitePawn[1] + 1] = 'w';
                    Console.WriteLine($"Game over! White capture on {field[whitePawn[0] - 1, whitePawn[1] + 1]}.");
                    break;
                }
                else
                {
                    if (IsInRangeOfMatrix(matrix, whitePawn[0] - 1, whitePawn[1]))

                    {
                        matrix[whitePawn[0], whitePawn[1]] = '-';
                        if (whitePawn[0] - 1 == 0)
                        {
                            Console.WriteLine($"Game over! White pawn is promoted to a queen at {field[whitePawn[0] - 1, whitePawn[1]]}.");
                            break;
                        }
                        else
                        {
                            matrix[whitePawn[0] - 1, whitePawn[1]] = 'w';
                            whitePawn[0] -= 1;
                        }
                    }
                }
                //// blackPawn move

                if (IsInRangeOfMatrix(matrix, blackPawn[0] + 1, blackPawn[1] - 1) && matrix[blackPawn[0] + 1, blackPawn[1] - 1] == 'w')
                {
                    matrix[blackPawn[0], blackPawn[1]] = '-';
                    matrix[blackPawn[0] + 1, blackPawn[1] - 1] = 'b';
                    Console.WriteLine($"Game over! Black capture on {field[blackPawn[0] + 1, blackPawn[1] - 1]}.");
                    break;
                }
                else if (IsInRangeOfMatrix(matrix, blackPawn[0] + 1, blackPawn[1] + 1) && matrix[blackPawn[0] + 1, blackPawn[1] + 1] == 'w')
                {
                    matrix[blackPawn[0], blackPawn[1]] = '-';
                    matrix[blackPawn[0] + 1, blackPawn[1] + 1] = 'b';
                    Console.WriteLine($"Game over! Black capture on {field[blackPawn[0] + 1, blackPawn[1] + 1]}.");
                    break;
                }
                else
                {
                    if (IsInRangeOfMatrix(matrix, blackPawn[0] + 1, blackPawn[1]))

                    {
                        matrix[blackPawn[0], blackPawn[1]] = '-';
                        if (blackPawn[0] + 1 == 7)
                        {
                            Console.WriteLine($"Game over! Black pawn is promoted to a queen at {field[blackPawn[0] + 1, blackPawn[1]]}.");
                            break;
                        }
                        else
                        {
                            matrix[blackPawn[0] + 1, blackPawn[1]] = 'b';
                        }
                    }
                }
            }

        }

        static char[,] ReadMatrixDataFromConsole(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] numbers = Console.ReadLine().ToLower().ToCharArray();


                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = numbers[cols];
                }
            }
            return matrix;
        }
        static string[,] ReadMatrixField(string[,] matrix)
        {
            for (int rows = 0; rows < 8; rows++)
            {
                char col = 'a';
                for (int cols = 0; cols < 8; cols++)
                {
                    matrix[rows, cols] = (char)col + (8 - rows).ToString();
                    col++;
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
        static int[] WhitePawnOnField(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] == 'w')
                    {
                        int[] pawnCoordinates = new int[2] { rows, cols };
                        return pawnCoordinates;
                    }
                }
            }
            return null;
        }
        static int[] BlackPawnOnField(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] == 'b')
                    {
                        int[] pawnCoordinates = new int[2] { rows, cols };
                        return pawnCoordinates;
                    }
                }
            }
            return null;
        }
  
    }
}
