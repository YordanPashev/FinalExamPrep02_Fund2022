using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> destiantions = new List<string>();
            int travelPoints = 0;

            string input = Console.ReadLine();
            string pattern = @"(\=|\/)(?<destination>[A-Z][A-Za-z]{2,})(\1)";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match currMatch in matches)
            {
                string currDestination = currMatch.Groups["destination"].Value;
                destiantions.Add(currDestination);
                travelPoints += currDestination.Length;
            }

            Console.WriteLine($"Destinations: {String.Join(", ", destiantions)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}