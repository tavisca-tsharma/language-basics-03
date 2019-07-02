using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            
            int[] calories = new int[protein.Length];

            // indexes of the menu selections that best suit each person's diet plan
            int[] answer = new int[expected.Length];

            // Calories Calculation
            CaloriesCalculaion(protein, carbs, fat, calories);
            
            // menu selections that best suit each person's diet plan
            MenuSelections(answer, dietPlans, protein, carbs, fat, calories);

            
            var result = answer.SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }


        // Calculation of Calories Array
        public static void CaloriesCalculaion(int[] protein, int[] carbs, int[] fat, int[] calories)
        {
            for (int i = 0; i < calories.Length; i++)
            {
                calories[i] = (protein[i] + carbs[i]) * 5 + fat[i] * 9;
            }
        }

        // menu selections that best suit each person's diet plan
        public static void MenuSelections(int[] answer, string[] dietPlans, int[] protein, int[] carbs, int[] fat, int[] calories)
        {
            for (int i = 0; i < answer.Length; i++)
            {

                if (dietPlans[i].Length == 0)
                {
                    answer[i] = 0;

                    continue;
                }
                List<int> ls = new List<int>();
                for (int j = 0; j < calories.Length; j++)
                    ls.Add(j);

                Meals.SelectMeals(protein, carbs, fat, calories, dietPlans[i], ls);
                answer[i] = ls[0];

            }
        }

    }

}
