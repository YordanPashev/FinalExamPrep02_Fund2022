using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace P02.EmojiDetector
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int treshholdSum = GetCoolThreshold(input);
            MatchCollection emojis = GetAllEmojis(input);
            DisplayAllCooldEmojis(emojis, treshholdSum);
        }

        static int GetCoolThreshold(string input)
        {
            Regex treshholdRegex = new Regex(@"\d");

            MatchCollection digits = treshholdRegex.Matches(input);
            int treshholdSum = 1;

            if (digits.Count > 1)
            {
                foreach (Match digit in digits)
                {
                    treshholdSum *= int.Parse(digit.Value);
                }
            }

            else
            {
                treshholdSum = int.Parse(digits[0].Value);
            }
           
            return treshholdSum;
        }

        static MatchCollection GetAllEmojis(string input)
        {
            Regex emojiRegex = new Regex(@"([:]{2}|[*]{2})(?<letters>[A-Z][a-z]{2,})\1");
            MatchCollection validEmojis = emojiRegex.Matches(input);
            return validEmojis;
        }

        static void DisplayAllCooldEmojis(MatchCollection emojis, int treshholdSum)
        {
            List<string> coolEmojis = new List<string>();

            foreach (Match emoji in emojis) 
            {
                string currEmojiLetters = emoji.Groups["letters"].Value;
                int letterSum = 0;

                foreach (char letter in currEmojiLetters)
                {
                    letterSum += letter;
                }

                if (letterSum >= treshholdSum)
                {
                    coolEmojis.Add(emoji.Value.ToString());
                }
            }

            Console.WriteLine($"Cool threshold: {treshholdSum}");
            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");

            if (coolEmojis.Count != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, coolEmojis));

            }
        }
    }
}
