using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsInMorseCode = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<char, string> morseCode = GetMorseCodeValues();

            foreach (string letter in wordsInMorseCode)
            {

                char translatedLetter = GetLetter(morseCode, letter);
                Console.Write(char.ToUpper(translatedLetter));
            }

            Console.WriteLine();
        }

        static Dictionary<char, string> GetMorseCodeValues()
        {
            Dictionary<char, string> mroseCode = new Dictionary<char, string>()
                                   {
                                       {'a', ".-"},
                                       {'b', "-..."},
                                       {'c', "-.-."},
                                       {'d', "-.."},
                                       {'e', "."},
                                       {'f', "..-."},
                                       {'g', "--."},
                                       {'h', "...."},
                                       {'i', ".."},
                                       {'j', ".---"},
                                       {'k', "-.-"},
                                       {'l', ".-.."},
                                       {'m', "--"},
                                       {'n', "-."},
                                       {'o', "---"},
                                       {'p', ".--."},
                                       {'q', "--.-"},
                                       {'r', ".-."},
                                       {'s', "..."},
                                       {'t', "-"},
                                       {'u', "..-"},
                                       {'v', "...-"},
                                       {'w', ".--"},
                                       {'x', "-..-"},
                                       {'y', "-.--"},
                                       {'z', "--.."},
                                       {' ', "|" }
                                   };

            return mroseCode;
        }


        static char GetLetter(Dictionary<char, string> morseCode, string symbolsToCheck)
        {
            char letterToAdd = '\0';

            foreach (var letter in morseCode)
            {
                if (letter.Value == symbolsToCheck)
                {
                    letterToAdd = letter.Key;
                }
            }

            return letterToAdd;
        }
    }
}