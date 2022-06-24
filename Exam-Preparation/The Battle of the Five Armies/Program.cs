using System;
using System.Linq;

namespace The_Battle_of_the_Five_Armies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int numRow = int.Parse(Console.ReadLine());
            char[][] matrix = new char[numRow][];
            ReadJaggedArray(numRow, matrix);

            bool armyAlive = true, mordorReached = false;
            while (armyAlive || !mordorReached)
            {
                string[] cmds = Console.ReadLine().Split();
                string move = cmds[0];
                int rowSpawn = int.Parse(cmds[1]);
                int colSpawn = int.Parse(cmds[2]);
                matrix[rowSpawn][colSpawn] = 'O';
                armor--;
                int[] army = FindArmyOnMap(matrix);
                if (move == "up") // row - 1 
                {
                    if (IsInRangeOfJaggedArray(matrix, army[0] - 1, army[1]))
                    {
                        if (matrix[army[0] - 1][army[1]] == 'O')
                        {
                            armor -= 2;
                            if (armor <= 0)
                            {
                                matrix[army[0] - 1][army[1]] = 'X';
                                matrix[army[0]][army[1]] = '-';
                                armyAlive = false;
                                break;
                            }
                            else
                            {
                                matrix[army[0] - 1][army[1]] = 'A';
                                matrix[army[0]][army[1]] = '-';
                            }
                        }
                        else if (matrix[army[0] - 1][army[1]] == 'M')
                        {
                            matrix[army[0]][army[1]] = '-';
                            matrix[army[0] - 1][army[1]] = '-';
                            mordorReached = true;
                            break;
                        }
                        else
                        {
                            matrix[army[0]][army[1]] = '-';
                            matrix[army[0] - 1][army[1]] = 'A';
                        }
                    }

                }
                else if (move == "down") // row +1  
                {
                    if (IsInRangeOfJaggedArray(matrix, army[0] + 1, army[1]))
                    {
                        if (matrix[army[0] + 1][army[1]] == 'O')
                        {
                            armor -= 2;
                            if (armor <= 0)
                            {
                                matrix[army[0] + 1][army[1]] = 'X';
                                matrix[army[0]][army[1]] = '-';
                                armyAlive = false;
                                break;
                            }
                            else
                            {
                                matrix[army[0] + 1][army[1]] = 'A';
                                matrix[army[0]][army[1]] = '-';
                            }
                        }
                        else if (matrix[army[0] + 1][army[1]] == 'M')
                        {
                            matrix[army[0]][army[1]] = '-';
                            matrix[army[0] + 1][army[1]] = '-';
                            mordorReached = true;
                            break;
                        }
                        else
                        {
                            matrix[army[0]][army[1]] = '-';
                            matrix[army[0] + 1][army[1]] = 'A';
                        }
                    }
                }
                else if (move == "left")// col -1 
                {
                    if (IsInRangeOfJaggedArray(matrix, army[0], army[1] - 1))
                    {
                        if (matrix[army[0]][army[1] - 1] == 'O')
                        {
                            armor -= 2;
                            if (armor <= 0)
                            {
                                matrix[army[0]][army[1] - 1] = 'X';
                                matrix[army[0]][army[1]] = '-';
                                armyAlive = false;
                                break;
                            }
                            else
                            {
                                matrix[army[0]][army[1] - 1] = 'A';
                                matrix[army[0]][army[1]] = '-';
                            }
                        }
                        else if (matrix[army[0]][army[1] - 1] == 'M')
                        {
                            matrix[army[0]][army[1]] = '-';
                            matrix[army[0]][army[1] - 1] = '-';
                            mordorReached = true;
                            break;
                        }
                        else
                        {
                            matrix[army[0]][army[1]] = '-';
                            matrix[army[0]][army[1] - 1] = 'A';
                        }
                    }

                }
                else if (move == "right")// col +1 
                {
                    if (IsInRangeOfJaggedArray(matrix, army[0], army[1] + 1))
                    {
                        if (matrix[army[0]][army[1] + 1] == 'O')
                        {
                            armor -= 2;
                            if (armor <= 0)
                            {
                                matrix[army[0]][army[1] + 1] = 'X';
                                matrix[army[0]][army[1]] = '-';
                                armyAlive = false;
                                break;
                            }
                            else
                            {
                                matrix[army[0]][army[1] + 1] = 'A';
                                matrix[army[0]][army[1]] = '-';
                            }
                        }
                        else if (matrix[army[0]][army[1] + 1] == 'M')
                        {
                            matrix[army[0]][army[1]] = '-';
                            matrix[army[0]][army[1] + 1] = '-';
                            mordorReached = true;
                            break;
                        }

                        else
                        {
                            matrix[army[0]][army[1]] = '-';
                            matrix[army[0]][army[1] + 1] = 'A';
                        }
                    }

                }
                if (armor <= 0)
                {
                    armyAlive = false;
                    int[] deadArmy = FindArmyOnMap(matrix);
                    matrix[deadArmy[0]][deadArmy[1]] = 'X';
                    break;
                }
            }
            if (!armyAlive)
            {
                int[] deadArmy = FindDeadArmyOnMap(matrix);
                Console.WriteLine($"The army was defeated at {deadArmy[0]};{deadArmy[1]}.");
            }
            else
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }
            PrintJaggedArray(matrix);
        }

        static void ReadJaggedArray(int rows, char[][] numbers)
        {
            for (int row = 0; row < rows; row++)
            {
                char[] inputRow = Console.ReadLine().ToUpper().ToCharArray();
                numbers[row] = new char[inputRow.Length];
                for (int col = 0; col < inputRow.Length; col++)
                {
                    numbers[row][col] = inputRow[col];
                }
            }
        }
        static void PrintJaggedArray(char[][] numbers)
        {
            foreach (var row in numbers)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
        static bool IsInRangeOfJaggedArray(char[][] jaggedArray, int row, int col)
        {
            if (row < jaggedArray.Length && col < jaggedArray[row].Length && row >= 0 && col >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static int[] FindArmyOnMap(char[][] numbers)
        {
            for (int row = 0; row < numbers.Length; row++)
            {
                for (int col = 0; col < numbers[row].Length; col++)
                {
                    if (numbers[row][col] == 'A')
                    {
                        return new int[2] { row, col };
                    }
                }
            }
            return null;
        }
        static int[] FindDeadArmyOnMap(char[][] numbers)
        {
            for (int row = 0; row < numbers.Length; row++)
            {
                for (int col = 0; col < numbers[row].Length; col++)
                {
                    if (numbers[row][col] == 'X')
                    {
                        return new int[2] { row, col };
                    }
                }
            }
            return null;
        }

    }
}
