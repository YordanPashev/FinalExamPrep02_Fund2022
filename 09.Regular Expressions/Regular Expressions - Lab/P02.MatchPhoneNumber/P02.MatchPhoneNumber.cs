using System;
using System.Text.RegularExpressions;

namespace P02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @"[\a|\+](359)([ |-])2\2(\d{3})\2(\d{4})\b";

            Regex pattern = new Regex(regex);

            string input = Console.ReadLine();
            MatchCollection matchedPhoneNumbers = pattern.Matches(input);

            Console.WriteLine(string.Join(", ", matchedPhoneNumbers));

        }
    }
}