using System;

namespace P06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintMiddleChar(input);
        }

        static void PrintMiddleChar(string input)
        {
            if (input.Length % 2 == 0)
            {
                char firstMidChar = input[(input.Length / 2) - 1];
                char secondMidChar = input[input.Length / 2];
                Console.WriteLine($"{firstMidChar}{secondMidChar}");
            }

            else
            {
                char midChar = input[input.Length / 2];
                Console.WriteLine(midChar);
            }
        }
    }
}
