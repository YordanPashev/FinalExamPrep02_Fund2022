using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace P02.MirrorWords

{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            string matchPattern = @"([@|#])(?<word>[A-Za-z]{3,})(\1)(\1)(?<reverse>[A-Za-z]{3,})(\1)";
            Regex wordPairVAlidator = new Regex(matchPattern);


            MatchCollection matchedPairs = wordPairVAlidator.Matches(inputLine);

            List<string> result = new List<string>();

            if (matchedPairs.Count > 0)
            {
                Console.WriteLine($"{matchedPairs.Count} word pairs found!");
                result = CheckForMirrorPairs(matchedPairs);
            }

            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (result.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", result));
            }

            else
            {
                Console.WriteLine("No mirror words!");
            }
        }

        static List<string> CheckForMirrorPairs(MatchCollection matchedPairs)
        {
            List<string> result = new List<string>();
            foreach (Match match in matchedPairs)
            {
                string firstWord = match.Groups["word"].Value;
                string mirrorWord = match.Groups["reverse"].Value;

                string reversedMirrordWord = string.Join("", mirrorWord.Reverse());

                if (firstWord == reversedMirrordWord)
                {
                    result.Add($"{firstWord} <=> {mirrorWord}");
                }
            }

            return result;
        }
    }
}


