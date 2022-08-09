using System;
using System.Linq;
using System.Text;

namespace LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            decimal totalResult = 0;

            foreach (string currStringExcerp in input)
            {
                char frontLetter = currStringExcerp.First();
                char backLetter = currStringExcerp.Last();

                decimal currDigit = ExtractDigitFromCurrString(currStringExcerp);
                    
                totalResult += CetTheResultForCurrPartition(frontLetter, backLetter, currDigit);
            }

            Console.WriteLine($"{totalResult:F2}");
        }

        static decimal CetTheResultForCurrPartition(char frontLetter, char backLetter, decimal digit)
        {
            decimal result = 0;

            if (char.IsUpper(frontLetter))
            {
                int letterPosition = frontLetter - 64;
                result = digit / letterPosition;
            }

            else
            {
                int letterPosition = frontLetter - 96;
                result = digit * letterPosition;
            }

            if (char.IsUpper(backLetter))
            {
                int letterPosition = backLetter - 64;
                result -= letterPosition;
            }

            else
            {
                int letterPosition = backLetter - 96;
                result += letterPosition;
            }

            return result;
        }

        static decimal ExtractDigitFromCurrString(string currStringExcerp)
        {
            StringBuilder currPart = new StringBuilder(currStringExcerp);

            int lastIndex = currPart.Length - 1;

            currPart.Remove(lastIndex, 1);
            currPart.Remove(0, 1);

            return decimal.Parse(currPart.ToString());
        }
    }
}