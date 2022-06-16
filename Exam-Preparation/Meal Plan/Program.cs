using System;
using System.Collections.Generic;
using System.Linq;

namespace Meal_Plan
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split());
            Stack<int> dailyCalories = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int currentDayCalories = dailyCalories.Pop();
            int eatenMeals = 0;
            while (currentDayCalories > 0 && meals.Count > 0)
            {
                int currMeal = CaloriesFromMeal(meals.Peek());
                if (currMeal < currentDayCalories)
                {
                    currentDayCalories -= currMeal;
                    eatenMeals++;
                    meals.Dequeue();
                    continue;
                }
                else if (currMeal > currentDayCalories && dailyCalories.Count > 0)
                {
                    currentDayCalories -= currMeal;
                    eatenMeals++;
                    meals.Dequeue();
                    currentDayCalories += dailyCalories.Pop();
                    continue;
                }
                else if (dailyCalories.Count == 0 && currentDayCalories > 0)
                {
                    meals.Dequeue();
                    eatenMeals++;
                    break;
                }
            }
            if (meals.Count == 0)
            {
                if (currentDayCalories > 0)
                {
                    dailyCalories.Push(currentDayCalories);
                }
                Console.WriteLine($"John had {eatenMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", dailyCalories)} calories.");
            }
            else if (dailyCalories.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {eatenMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
        static int CaloriesFromMeal(string meal)
        {
            int calories;
            switch (meal)
            {
                case "salad":
                    calories = 350;
                    break;
                case "soup":
                    calories = 490;
                    break;
                case "pasta":
                    calories = 680;
                    break;
                case "steak":
                    calories = 790;
                    break;
                default:
                    calories = 0;
                    break;
            }
            return calories;
        }
    }
}
