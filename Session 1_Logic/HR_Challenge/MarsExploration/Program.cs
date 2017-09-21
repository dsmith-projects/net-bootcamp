using System;

namespace MarsExploration
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string S = Console.ReadLine();

            int count = 0;
            string[] a = new string[S.Length / 3];

            int i = 0;
            do
            {
                string chunk = S.Substring(i, 3);
                a[i] = chunk;
                i = i + 3;
            } while (i < S.Length);

            for (int i = 0; i < a.Length; i++)
            {
                //if (a[i])
                //{

                //}
            }
        }
    }
}
