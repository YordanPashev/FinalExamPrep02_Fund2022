using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] encodingListOfNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string input = Console.ReadLine();

            List<char> text = input.ToList();

            for (int i = 0; i < encodingListOfNumbers.Length; i++)
            {
                List<int> currentIndexDigits = new List<int>();

                foreach (char digit in encodingListOfNumbers[i])
                {
                    currentIndexDigits.Add((int)char.GetNumericValue(digit));
                }

                int indexToFindInTheText = currentIndexDigits.Sum();

                if (indexToFindInTheText < text.Count)
                {
                    Console.Write(text[indexToFindInTheText]);
                    text.RemoveAt(indexToFindInTheText);
                }

                else
                {
                    indexToFindInTheText -= text.Count;
                    Console.Write(text[indexToFindInTheText]);
                    text.RemoveAt(indexToFindInTheText);
                }
            }
        }
    }
}