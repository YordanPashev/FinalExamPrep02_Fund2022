using System;

namespace P04.SumOfChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfChars = int.Parse(Console.ReadLine());
            int result = 0;
            for (int i = 0; i < numberOfChars; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                result += letter;
            }
            Console.WriteLine($"The sum equals: {result}");
        }
    }
}
