using System;

namespace P01.Encrypt_SortAndPrintArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int[] scores = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                string letter = Console.ReadLine();

                int vowelsSum = 0;
                int consonantSum = 0;

                for (int j = 0; j < letter.Length; j++)
                {
                    if (letter[j] == 'a' || letter[j] == 'e' ||
                        letter[j] == 'i' || letter[j] == 'o' || letter[j] == 'u' ||
                        letter[j] == 'A' || letter[j] == 'E' ||
                        letter[j] == 'I' || letter[j] == 'O' || letter[j] == 'U')
                    {
                        vowelsSum += (int)letter[j] * letter.Length;
                    }
                    else
                    {
                        consonantSum += (int)letter[j] / letter.Length;
                    }
                }
                scores[i] = consonantSum + vowelsSum;
            }

            Array.Sort(scores);

            foreach (int result in scores)
            {
                Console.WriteLine(result);
            }
        }
    }
}
