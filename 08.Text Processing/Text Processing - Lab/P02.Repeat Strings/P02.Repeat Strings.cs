using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Repeat Strings
{
    class Program
    {
        static void Main(string[] Args)
        {
            string[] listOfWords = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            StringBuilder result = new StringBuilder();

            for (int wordIndex = 0; wordIndex < listOfWords.Length; wordIndex++)
            {
                string currWord = listOfWords[wordIndex];
                int currWordlenght = listOfWords[wordIndex].Length;
                for (int charIndex = 0; charIndex < currWordlenght; charIndex++)
                {
                    result.Append(currWord);
                }
            }

            Console.WriteLine(result);
        }
    }
}