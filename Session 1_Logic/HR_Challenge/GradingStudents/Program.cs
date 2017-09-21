using System;

namespace GradingStudents
{
    class MainClass
    {
		
        static int MultiploDe5MasCercano(int n) { // n = 42 (5*8)= 40
            int multiploDe5 = 1;
            int i = 0;
            while(multiploDe5 < n) {
                multiploDe5 = 5 * i;
                i++;
            }
            //Console.WriteLine("MultiploDe5MasCercano: "+ multiploDe5);
            return multiploDe5;
        }

        static int[] Solve(int[] grades)
		{
            int multiploDe5MasCercano = 0;
            int[] result = new int[grades.Length];
            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] < 38)
                {
                    result[i] = grades[i];
                }
                else
                {
                    multiploDe5MasCercano = MultiploDe5MasCercano(grades[i]);
                    if (multiploDe5MasCercano - grades[i] < 3)
                    {
                        result[i] = multiploDe5MasCercano;
                    }
                    else
                    {
                        result[i] = grades[i];
                    }
                }
            }
            return result;
        }

        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] grades = new int[n];
            for (int grades_i = 0; grades_i < n; grades_i++)
            {
                grades[grades_i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] result = Solve(grades);
            Console.WriteLine(String.Join("\n", result));
        }
    }
}
