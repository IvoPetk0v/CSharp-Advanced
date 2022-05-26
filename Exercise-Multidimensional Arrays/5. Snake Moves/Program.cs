using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
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
            string input = Console.ReadLine();
            Queue<char> snake = new Queue<char>();
            foreach (char ch in input)
            {
                snake.Enqueue(ch);
            }
            Queue<char> snakeInMotion = new Queue<char>(snake);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if ((row + 1) % 2 != 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (snakeInMotion.Count == 1)
                        {
                            matrix[row, col] = snakeInMotion.Dequeue();
                            snakeInMotion = new Queue<char>(snake);
                        }
                        else
                        {
                            matrix[row, col] = snakeInMotion.Dequeue();
                        }
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1)-1; col >= 0; col--)
                    {
                        if (snakeInMotion.Count == 1)
                        {
                            matrix[row, col] = snakeInMotion.Dequeue();
                            snakeInMotion = new Queue<char>(snake);
                        }
                        else
                        {
                            matrix[row, col] = snakeInMotion.Dequeue();
                        }
                    }
                }
            }
            PrintMatrix(matrix);
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols]);
                }
                Console.WriteLine();
            }
        }
    }
}
