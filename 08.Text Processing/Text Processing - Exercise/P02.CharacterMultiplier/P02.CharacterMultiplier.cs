using System;
using System.Linq;
using System.Text;

namespace CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            string[] orderedWordsByLenght = GeShorterWord(inputLine);

            int totalResult = MultiplyAllChars(orderedWordsByLenght);

            Console.WriteLine(totalResult);
        }

        static string[] GeShorterWord(string[] inputLine)
        {
            string firstString = inputLine[0];
            string secondString = inputLine[1];

            if(firstString.Length >= secondString.Length)
            {
                return new string[] { secondString, firstString };
            }

            else
            {
                return new string[] { firstString, secondString };
            }
        }

        static int MultiplyAllChars(string[] orderedWordsByLenght)
        {
            StringBuilder shorterWord = new StringBuilder(orderedWordsByLenght[0]);
            StringBuilder longerWord = new StringBuilder(orderedWordsByLenght[1]);

            int totalResult = 0;

            while(shorterWord.Length > 0)
            {
                totalResult += shorterWord[0] * longerWord[0];
                shorterWord.Remove(0, 1);
                longerWord.Remove(0, 1);
            }

            if (longerWord.Length > 0)
            {
                for (int i = 0; i < longerWord.Length; i++)
                {
                    totalResult += longerWord[i];
                }
            }

            return totalResult;
        }
    }
}