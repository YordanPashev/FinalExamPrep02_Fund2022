using System;

namespace P02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(PrintNumberOfVowels(input));
        }
        static double PrintNumberOfVowels(string input)
        {
            int vowelsCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || input[i] == 'e' ||
                    input[i] == 'i' || input[i] == 'o' ||
                    input[i] == 'u' || input[i] == 'A' || input[i] == 'E' ||
                    input[i] == 'I' || input[i] == 'O' ||
                    input[i] == 'U')
                {
                    vowelsCounter++;
                }
            }
            return vowelsCounter;
        }
    }
}
