using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, int> racers = AddAllParticipantsToDictionary(participants);

            string letterPattern = @"[A-Za-z]{1}";
            string digitPattern = @"\d{1}";
            Regex regexForLetters = new Regex(letterPattern);
            Regex regexDigits = new Regex(digitPattern);

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                MatchCollection matchName = regexForLetters.Matches(input);
                string name = string.Join("", matchName);

                if (racers.Keys.Contains(name))
                {
                    MatchCollection matchDigits = regexDigits.Matches(input);
                    AddPointToCurrentRacer(name, matchDigits, racers);
                }
            }

            DisplayTopThreeRacers(racers);
        }

        static Dictionary<string, int> AddAllParticipantsToDictionary(string[] participants)
        {
            Dictionary<string, int> racers = new Dictionary<string, int>();

            foreach (var participant in participants)
            {
                racers.Add(participant, 0);
            }

            return racers;
        }

        static void AddPointToCurrentRacer(string name, MatchCollection matchDigits,  Dictionary<string, int> racers)
        {
            int pointsToAdd = 0;

            foreach (Match digit in matchDigits)
            {
                int currDigit = int.Parse(digit.Value);
                pointsToAdd += currDigit;
            }

            racers[name] += pointsToAdd;
        }

        static void DisplayTopThreeRacers(Dictionary<string, int> racers)
        {
            List<string> topThreeRacers = new List<string>();

            var orderedRacers = racers.OrderByDescending(x => x.Value);

            int counter = 0;

            foreach (var racer in orderedRacers)
            {
                if (counter >= 3)
                {
                    break;
                }

                topThreeRacers.Add(racer.Key);
                counter++;
            }

            Console.WriteLine($"1st place: {topThreeRacers[0]}");
            Console.WriteLine($"2nd place: {topThreeRacers[1]}");
            Console.WriteLine($"3rd place: {topThreeRacers[2]}");
        }
    }
}