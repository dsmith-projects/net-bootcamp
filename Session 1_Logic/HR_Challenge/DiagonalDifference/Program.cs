using System;

namespace DiagonalDifference
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			int n = Convert.ToInt32(Console.ReadLine());
			int[][] a = new int[n][];
			for (int a_i = 0; a_i < n; a_i++)
			{
				string[] a_temp = Console.ReadLine().Split(' ');
				a[a_i] = Array.ConvertAll(a_temp, Int32.Parse);
			}
			int diagonal1 = 0;
			int diagonal2 = 0;
			
            for (int i = n - 1, j = 0; i >= 0; i--, j++)
			{
                diagonal1 += a[i][i];
                diagonal2 += a[i][j];
			}

            //Console.WriteLine("Diagonal 1: " + diagonal1);
            //Console.WriteLine("Diagonal 2: " + diagonal2);
			int resultado = diagonal1 - diagonal2;

			if (resultado < 0)
			{
				//Console.WriteLine("Resultado: " + resultado * -1);
                Console.WriteLine(resultado * -1);
			}
			else
			{
				//Console.WriteLine("Resultado: " + resultado);
                Console.WriteLine(resultado);
			}
        }
    }
}
