using System;
using System.Linq;

namespace P01.ActivationKey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawActKey = Console.ReadLine();
            string cmd;

            while ((cmd = Console.ReadLine()) != "Generate")
            {
                string[] cmdArgs = cmd
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = cmdArgs[0];

                if (action == "Contains")
                {
                    string substringToFind = cmdArgs[1];
                    rawActKey = CheckIfKeyContainsThisSubstring(rawActKey, substringToFind);
                }

                else if (action == "Flip")
                {
                    rawActKey = ChangesTheSubstringBetweenTheGivenIndices(rawActKey, cmdArgs);
                    Console.WriteLine(rawActKey);
                }

                else if (action == "Slice")
                {
                    rawActKey = DeletesTheCharactersBetweenTheGivenIndices(rawActKey, cmdArgs);
                    Console.WriteLine(rawActKey);
                }
            }

            Console.WriteLine($"Your activation key is: {rawActKey}");
        }

        static string CheckIfKeyContainsThisSubstring(string rawActKey, string substring)
        {
            if (rawActKey.Contains(substring))
            {
                Console.WriteLine($"{rawActKey} contains {substring}");
            }

            else
            {
                Console.WriteLine("Substring not found!");
            }

            return rawActKey;
        }

        static string ChangesTheSubstringBetweenTheGivenIndices(string rawActKey, string[] cmdArgs)
        {
            string flipArgs = cmdArgs[1];
            int startIndex = int.Parse(cmdArgs[2]);
            int endIndex = int.Parse(cmdArgs[3]);
            int charNumberToChange = endIndex - startIndex;

            if (flipArgs == "Upper")
            {
                string substringToFLip = rawActKey.Substring(startIndex, charNumberToChange);
                rawActKey = rawActKey.Replace(substringToFLip, substringToFLip.ToUpper());
            }

            else if (flipArgs == "Lower")
            {
                string substringToFLip = rawActKey.Substring(startIndex, charNumberToChange);
                rawActKey = rawActKey.Replace(substringToFLip, substringToFLip.ToLower());
            }

            return rawActKey;
        }

        static string DeletesTheCharactersBetweenTheGivenIndices(string rawActKey, string[] cmdArgs)
        {
            int startIndex = int.Parse(cmdArgs[1]);
            int endIndex = int.Parse(cmdArgs[2]);
            int charNumberToDelete = endIndex - startIndex;

            rawActKey = rawActKey.Remove(startIndex, charNumberToDelete);

            return rawActKey;
        }
    }
}