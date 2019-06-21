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
            try {
                Console.ReadKey(true);
            } catch (Exception e) {}
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            //Console.WriteLine("1");
            int[] calories = new int[protein.Length];
            int[] answer = new int[expected.Length];

            for (int i=0; i<calories.Length; i++){
                calories[i] = ( protein[i] + carbs[i] ) * 5 + fat[i] * 9;
            }

            for (int i=0; i<answer.Length; i++) {
                //Console.WriteLine("i="+i);
                if (dietPlans[i].Length==0){
                    answer[i]=0;
                    //Console.WriteLine("answer = "+answer[i]);
                    continue;
                }
                List<int> ls = new List<int>();
                for (int j=0; j<calories.Length; j++)
                    ls.Add(j);
                //Console.WriteLine("dietplan[i]= "+dietPlans[i]);
                SelectMeals(protein, carbs, fat, calories, dietPlans[i], ls);
                answer[i] = ls[0];
                //Console.WriteLine("answer = "+answer[i]);
            }
            //Console.WriteLine("3");

            /*foreach(int k in answer){
                Console.Write(k+"  ");
            }
            Console.WriteLine(" ");*/

            var result = answer.SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

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
            int i=0;
            for (i=1; i<ls.Count; i++){
                if ( max < calories[ls[i]] )
                    max = calories[ls[i]];
            }
            i=0;
            while (i<ls.Count){
                if ( max != calories[ls[i]] )
                    ls.RemoveAt(i);
                else
                    i++;
            }

            if (dietPlans.Length>1 && ls.Count>1)
                SelectMeals (protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }

        private static void LowCalories(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("LowCalories");
            int min = calories[ls[0]];
            int i=0;
            for (i=1; i<ls.Count; i++){
                if ( min > calories[ls[i]] )
                    min = calories[ls[i]];
            }
            i=0;
            while (i<ls.Count){
                if ( min != calories[ls[i]] )
                    ls.RemoveAt(i);
                else
                    i++;
            }

            if (dietPlans.Length>1 && ls.Count>1)
                SelectMeals (protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }

        private static void HighFat(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("HighFat");
            int max = fat[ls[0]];
            int i=0;
            for (i=1; i<ls.Count; i++){
                if ( max < fat[ls[i]] )
                    max = fat[ls[i]];
            }
            i=0;
            while (i<ls.Count){
                if ( max != fat[ls[i]] )
                    ls.RemoveAt(i);
                
                else
                    i++;
            }

            if (dietPlans.Length>1 && ls.Count>1)
                SelectMeals (protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }

        private static void LowFat(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("LowFat");
            int min = fat[ls[0]];
            int i=0;
            for (i=1; i<ls.Count; i++){
                if ( min > fat[ls[i]] )
                    min = fat[ls[i]];
            }
            i=0;
            while (i<ls.Count){
                if ( min != fat[ls[i]] )
                    ls.RemoveAt(i);
                else
                    i++;
            }

            if (dietPlans.Length>1 && ls.Count>1)
                SelectMeals (protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }

        private static void HighCarbs(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("HighCarbs");
            int max = carbs[ls[0]];
            int i=0;
            for (i=1; i<ls.Count; i++){
                if ( max < carbs[ls[i]] )
                    max = carbs[ls[i]];
            }
            i=0;
            while (i<ls.Count){
                if ( max != carbs[ls[i]] )
                    ls.RemoveAt(i);
                else
                    i++;
            }

            if (dietPlans.Length>1 && ls.Count>1)
                SelectMeals (protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }

        private static void LowCarbs(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("LowCarbs");
            int min = carbs[ls[0]];
            int i=0;
            for (i=1; i<ls.Count; i++){
                if ( min > carbs[ls[i]] )
                    min = carbs[ls[i]];
            }
            i=0;
            while (i<ls.Count){
                if ( min != carbs[ls[i]] )
                    ls.RemoveAt(i);
                else
                    i++;
            }

            if (dietPlans.Length>1 && ls.Count>1)
                SelectMeals (protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }

        private static void HighProtein(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("HighProtein");
            int max = protein[ls[0]];
            int i=0;
            for (i=1; i<ls.Count; i++){
                if ( max < protein[ls[i]] )
                    max = protein[ls[i]];
            }
            i=0;
            while (i<ls.Count){
                if ( max != protein[ls[i]] )
                    ls.RemoveAt(i);
                else
                    i++;
            }

            if (dietPlans.Length>1 && ls.Count>1)
                SelectMeals (protein, carbs, fat, calories, dietPlans.Substring(1), ls);

        }

        private static void LowProtein(int[] protein, int[] carbs, int[] fat, int[] calories, string dietPlans, List<int> ls)
        {
            //Console.WriteLine("LowProtein");
            int min = protein[ls[0]];
            int i=0;
            for (i=1; i<ls.Count; i++){
                if ( min > protein[ls[i]] )
                    min = protein[ls[i]];
            }
            i=0;
            while (i<ls.Count){
                if ( min != protein[ls[i]] )
                    ls.RemoveAt(i);
                else
                    i++;
            }

            if (dietPlans.Length>1 && ls.Count>1)
                SelectMeals (protein, carbs, fat, calories, dietPlans.Substring(1), ls);
            
        }
        
    }

}
