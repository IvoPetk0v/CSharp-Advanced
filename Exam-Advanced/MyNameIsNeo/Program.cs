using System;
using System.Collections.Generic;
using System.Linq;

namespace MyNameIsNeo
{
    class Program
    {
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
        static int[] VankoOnField(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] == 'V')
                    {
                        int[] vankoCoordinates = new int[2] { rows, cols };
                        return vankoCoordinates;
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

        static void Main(string[] args)
        {
            int numRow = int.Parse(Console.ReadLine());
            char[,] wall = new char[numRow, numRow];
            ReadMatrixDataFromConsole(wall);
            int rodHit = 0, holeDig =1;
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                char spot;
                int[] vanko = VankoOnField(wall);
              
                if (cmd == "up") // row - 1 
                {
                    if (IsInRangeOfMatrix(wall, vanko[0] - 1, vanko[1]))
                    {
                        spot = wall[vanko[0] - 1, vanko[1]];
                        if (spot == '-')
                        {
                            wall[vanko[0], vanko[1]] = '*';
                            holeDig++;
                            wall[vanko[0] - 1, vanko[1]] = 'V';
                        }
                        else if (spot == 'C')
                        {
                            wall[vanko[0], vanko[1]] = '*';
                            wall[vanko[0] - 1, vanko[1]] = 'E';
                            holeDig++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeDig} hole(s).");
                            PrintMatrix(wall);
                            return;
                        }
                        else if (spot == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodHit++;                           
                        }
                        else if (spot == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vanko[0] - 1}, {vanko[1]}]!");
                            wall[vanko[0] - 1, vanko[1]] = 'V';
                            wall[vanko[0], vanko[1]] = '*';
                        }
                    }                  
                }
                else if (cmd == "down") //row +1 
                {
                    if (IsInRangeOfMatrix(wall, vanko[0] + 1, vanko[1]))
                    {
                        spot = wall[vanko[0] + 1, vanko[1]];
                        if (spot == '-')
                        {
                            wall[vanko[0], vanko[1]] = '*';
                            holeDig++;
                            wall[vanko[0] + 1, vanko[1]] = 'V';
                        }
                        else if (spot == 'C')
                        {
                            wall[vanko[0], vanko[1]] = '*';
                            wall[vanko[0] + 1, vanko[1]] = 'E';
                            holeDig++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeDig} hole(s).");
                            PrintMatrix(wall);
                            return;
                        }
                        else if (spot == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodHit++;  
                        }
                        else if (spot == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vanko[0] + 1}, { vanko[1]}]!");
                            wall[vanko[0] + 1, vanko[1]] = 'V';
                            wall[vanko[0], vanko[1]] = '*'; 
                        }
                    }               
                }
                else if (cmd == "left") // col-1 
                {
                    if (IsInRangeOfMatrix(wall, vanko[0], vanko[1] - 1))
                    {
                        spot = wall[vanko[0], vanko[1] - 1];
                        if (spot == '-')
                        {
                            wall[vanko[0], vanko[1]] = '*';
                            holeDig++;
                            wall[vanko[0], vanko[1] - 1] = 'V';
                        }
                        else if (spot == 'C')
                        {
                            wall[vanko[0], vanko[1]] = '*';
                            wall[vanko[0], vanko[1] - 1] = 'E';
                            holeDig++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeDig} hole(s).");
                            PrintMatrix(wall);
                            return;
                        }
                        else if (spot == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodHit++;                         
                        }
                        else if (spot == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vanko[0]}, { vanko[1] - 1}]!");
                            wall[vanko[0], vanko[1] - 1] = 'V';
                            wall[vanko[0], vanko[1]] = '*';                        
                        }
                    }                 
                }
                else if (cmd == "right") // col+1
                {
                    if (IsInRangeOfMatrix(wall, vanko[0], vanko[1] + 1))
                    {
                        spot = wall[vanko[0], vanko[1] + 1];
                        if (spot == '-')
                        {
                            wall[vanko[0], vanko[1]] = '*';
                            holeDig++;
                            wall[vanko[0], vanko[1] + 1] = 'V';
                        }
                        else if (spot == 'C')
                        {
                            wall[vanko[0], vanko[1]] = '*';
                            wall[vanko[0], vanko[1] + 1] = 'E';
                            holeDig++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeDig} hole(s).");
                            PrintMatrix(wall);
                            return;
                        }
                        else if (spot == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodHit++;                         
                        }
                        else if (spot == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vanko[0]}, { vanko[1] + 1}]!");
                            wall[vanko[0], vanko[1] + 1] = 'V';
                            wall[vanko[0], vanko[1]] = '*';
                        }
                    }                 
                }
            }
            Console.WriteLine($"Vanko managed to make {holeDig} hole(s) and he hit only {rodHit} rod(s).");
            PrintMatrix(wall);
        }
    }
}
