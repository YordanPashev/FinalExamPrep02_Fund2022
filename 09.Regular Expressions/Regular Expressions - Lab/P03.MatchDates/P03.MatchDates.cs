using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string datePattern = @"\b(?<day>\d{2})([.|\-|\/])(?<moth>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            Regex pattern = new Regex(datePattern);
            MatchCollection validDates = pattern.Matches(input);

            foreach (Match match in validDates)
            {
                string day = match.Groups["day"].Value;
                string moth = match.Groups["moth"].Value;
                string year = match.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {moth}, Year: {year}");
            }
        }
    }
}