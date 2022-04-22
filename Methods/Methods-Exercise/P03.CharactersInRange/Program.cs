using System;

namespace P03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            Console.WriteLine(PrintCharactersInRange(start, end));

        }

        static string PrintCharactersInRange(char start, char end)
        {

            string result = string.Empty;
            int j = 0;
            char[] currentChar = new char[Math.Abs(end - start)];
            if (start < end)
            {
                int asciiValue = start;

                for (int i = asciiValue + 1; i < end; i++, j++)
                {
                    currentChar[j] = (char)(i);

                }
            }

            else
            {
                int asciiValue = end;

                for (int i = asciiValue + 1; i < start; i++, j++)
                {
                    currentChar[j] = (char)(i);
                }
            }
            char[] currentChar2 = new char[currentChar.Length - 1];

            for (int i = 0; i < currentChar2.Length; i++)
            {
                currentChar2[i] = currentChar[i];
            }
            result = string.Join(" ", currentChar2);
            return result;
        }
    }
}