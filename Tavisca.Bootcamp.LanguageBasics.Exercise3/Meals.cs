using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Meals
    {
        public static void SelectMeals(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine(dietPlans);
            //Console.WriteLine("4");
            if (dietPlans.Substring(0, 1).Equals("p"))
                LowProtein(protein, carbs, fat, calories, dietPlans, ls);
            else if (dietPlans.Substring(0, 1).Equals("P"))
                HighProtein(protein, carbs, fat, calories, dietPlans, ls);
            else if (dietPlans.Substring(0, 1).Equals("c"))
                LowCarbs(protein, carbs, fat, calories, dietPlans, ls);
            else if (dietPlans.Substring(0, 1).Equals("C"))
                HighCarbs(protein, carbs, fat, calories, dietPlans, ls);
            else if (dietPlans.Substring(0, 1).Equals("f"))
                LowFat(protein, carbs, fat, calories, dietPlans, ls);
            else if (dietPlans.Substring(0, 1).Equals("F"))
                HighFat(protein, carbs, fat, calories, dietPlans, ls);
            else if (dietPlans.Substring(0, 1).Equals("t"))
                LowCalories(protein, carbs, fat, calories, dietPlans, ls);
            else
                HighCalories(protein, carbs, fat, calories, dietPlans, ls);
        }

        private static void HighCalories(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("HighCalories");
            int max = calories[ls[0]];
            int i = 0;
            for (i = 1; i < ls.Count; i++)
            {
                if (max < calories[ls[i]])
                    max = calories[ls[i]];
            }
            i = 0;
            while (i < ls.Count)
            {
                if (max != calories[ls[i]])
                    ls.RemoveAt(i);
                else
                    i++;
            }

            if (dietPlans.Length > 1 && ls.Count > 1)
                SelectMeals(protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }

        private static void LowCalories(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("LowCalories");
            int min = calories[ls[0]];
            int i = 0;
            for (i = 1; i < ls.Count; i++)
            {
                if (min > calories[ls[i]])
                    min = calories[ls[i]];
            }
            i = 0;
            while (i < ls.Count)
            {
                if (min != calories[ls[i]])
                    ls.RemoveAt(i);
                else
                    i++;
            }

            if (dietPlans.Length > 1 && ls.Count > 1)
                SelectMeals(protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }

        private static void HighFat(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("HighFat");
            int max = fat[ls[0]];
            int i = 0;
            for (i = 1; i < ls.Count; i++)
            {
                if (max < fat[ls[i]])
                    max = fat[ls[i]];
            }
            i = 0;
            while (i < ls.Count)
            {
                if (max != fat[ls[i]])
                    ls.RemoveAt(i);

                else
                    i++;
            }

            if (dietPlans.Length > 1 && ls.Count > 1)
                SelectMeals(protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }

        private static void LowFat(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("LowFat");
            int min = fat[ls[0]];
            int i = 0;
            for (i = 1; i < ls.Count; i++)
            {
                if (min > fat[ls[i]])
                    min = fat[ls[i]];
            }
            i = 0;
            while (i < ls.Count)
            {
                if (min != fat[ls[i]])
                    ls.RemoveAt(i);
                else
                    i++;
            }

            if (dietPlans.Length > 1 && ls.Count > 1)
                SelectMeals(protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }

        private static void HighCarbs(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("HighCarbs");
            int max = carbs[ls[0]];
            int i = 0;
            for (i = 1; i < ls.Count; i++)
            {
                if (max < carbs[ls[i]])
                    max = carbs[ls[i]];
            }
            i = 0;
            while (i < ls.Count)
            {
                if (max != carbs[ls[i]])
                    ls.RemoveAt(i);
                else
                    i++;
            }

            if (dietPlans.Length > 1 && ls.Count > 1)
                SelectMeals(protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }

        private static void LowCarbs(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("LowCarbs");
            int min = carbs[ls[0]];
            int i = 0;
            for (i = 1; i < ls.Count; i++)
            {
                if (min > carbs[ls[i]])
                    min = carbs[ls[i]];
            }
            i = 0;
            while (i < ls.Count)
            {
                if (min != carbs[ls[i]])
                    ls.RemoveAt(i);
                else
                    i++;
            }

            if (dietPlans.Length > 1 && ls.Count > 1)
                SelectMeals(protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }

        private static void HighProtein(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("HighProtein");
            int max = protein[ls[0]];
            int i = 0;
            for (i = 1; i < ls.Count; i++)
            {
                if (max < protein[ls[i]])
                    max = protein[ls[i]];
            }
            i = 0;
            while (i < ls.Count)
            {
                if (max != protein[ls[i]])
                    ls.RemoveAt(i);
                else
                    i++;
            }

            if (dietPlans.Length > 1 && ls.Count > 1)
                SelectMeals(protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }

        private static void LowProtein(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("LowProtein");
            int min = protein[ls[0]];
            int i = 0;
            for (i = 1; i < ls.Count; i++)
            {
                if (min > protein[ls[i]])
                    min = protein[ls[i]];
            }
            i = 0;
            while (i < ls.Count)
            {
                if (min != protein[ls[i]])
                    ls.RemoveAt(i);
                else
                    i++;
            }

            if (dietPlans.Length > 1 && ls.Count > 1)
                SelectMeals(protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }
    }
}
