using System;

namespace MarcsCakewalk
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			int n = Convert.ToInt32(Console.ReadLine());
			string[] calories_temp = Console.ReadLine().Split(' ');
			int[] calories = Array.ConvertAll(calories_temp, Int32.Parse);
            // We first need to sort the calories array in descending order
            int temp = 0;
            long miles = 0;

			for (int i = 0; i < calories.Length - 1; i++)
            {
                for (int j = i + 1; j < calories.Length; j++)
                {
                    if(calories[j] > calories[i]) {
                        temp = calories[i];
                        calories[i] = calories[j];
                        calories[j] = temp;
                    }
                }
            }

            for (int i = 0; i < calories.Length; i++)
            {
                miles += Convert.ToInt64(Math.Pow(2, i)) * calories[i];
            }

            Console.WriteLine(miles);
        }
    }
}
