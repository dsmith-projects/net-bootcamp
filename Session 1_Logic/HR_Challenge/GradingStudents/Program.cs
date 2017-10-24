using System;

namespace GradingStudents
{
    class MainClass
    {
		
        static int MultiploDe5MasCercano(int n) { // n = 42 (5*8)= 40
            int multiplicidad = 5;
            int cociente = (n / multiplicidad);
            int multiploDe5 = (cociente * multiplicidad) + multiplicidad; ;
            //Console.WriteLine("MultiploDe5MasCercano: " + multiploDe5);
            return multiploDe5;
        }

        static void Solve(ref int[] grades)
		{
            int multiploDe5MasCercano = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] >= 38)
                {
                    multiploDe5MasCercano = MultiploDe5MasCercano(grades[i]);
                    if (multiploDe5MasCercano - grades[i] < 3)
                    {
                        grades[i] = multiploDe5MasCercano;
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] grades = new int[n];
            for (int grades_i = 0; grades_i < n; grades_i++)
            {
                grades[grades_i] = Convert.ToInt32(Console.ReadLine());
            }
            Solve(ref grades);
			for (int grades_i = 0; grades_i < n; grades_i++)
			{
				Console.WriteLine(grades[grades_i]); 
			}

        }
    }
}
