using System;

namespace MarsExploration
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string S = Console.ReadLine();
            string[] a = new string[S.Length / 3];
            int corruptedLetters = 0;
            int count = 0;
            int i = 0;
            do
            {
                string chunk = S.Substring(i, 3);
                a[count++] = chunk;
                i = i + 3;
            } while (i < S.Length);

            for (int j = 0; j < a.Length; j++)
            {
                if (a[j][0] != 'S')
                {
                    corruptedLetters++;
                }
				if (a[j][1] != 'O')
				{
					corruptedLetters++;
				}
				if (a[j][2] != 'S')
				{
					corruptedLetters++;
				}
            }
            Console.WriteLine(corruptedLetters);
        }
    }
}
