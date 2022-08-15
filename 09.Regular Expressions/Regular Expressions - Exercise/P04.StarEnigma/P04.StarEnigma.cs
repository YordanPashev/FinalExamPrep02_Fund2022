using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace P04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            string messagePattern = @"@(?<name>[A-Z][a-z]+)[^@:!\->]*?:(?<population>\d+)[^@:!\->]*?!(?<atype>D|A)![^@:!\->]*?->(?<soldiers>\d+)";

            Regex starLetters = new Regex(@"[SsTtAaRr]");

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfLines; i++)
            {
                string decryptedMessage = Console.ReadLine();

                string encryptedMessage = EncryptMessage(decryptedMessage, starLetters);

                Match match = Regex.Match(encryptedMessage.ToString(), messagePattern);

                if (match.Success)
                {
                    AddPlanetToCorrespondingList(match, destroyedPlanets, attackedPlanets);
                }
            }

            DisplayAllPlanets(attackedPlanets, destroyedPlanets);
        }

        static void AddPlanetToCorrespondingList(Match match, List<string> destroyedPlannets, List<string> attackedPlannets)
        {
            string planetName = match.Groups["name"].Value;
            char atackType = char.Parse(match.Groups["atype"].Value);

            if (atackType == 'D')
            {
                destroyedPlannets.Add(planetName);
            }

            else if (atackType == 'A')
            {
                attackedPlannets.Add((planetName));
            }
        }

        static string EncryptMessage(string decryptedMessage, Regex starLetters)
        {

            MatchCollection allStarLetter = starLetters.Matches(decryptedMessage);

            int deductionCharNumber = allStarLetter.Count;

            StringBuilder encryptedMessage = new StringBuilder();

            foreach (char symbol in decryptedMessage)
            {
                encryptedMessage.Append((char)(symbol - deductionCharNumber));
            }

            return encryptedMessage.ToString();
        }

        static void DisplayAllPlanets(List<string> attackedPlanets, List<string> destroyedPlanets)
        {
            attackedPlanets.Sort();
            destroyedPlanets.Sort();

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planetName in attackedPlanets)
            {
                Console.WriteLine($"-> {planetName}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planetName in destroyedPlanets)
            {
                Console.WriteLine($"-> {planetName}");
            }
        }
    }
}