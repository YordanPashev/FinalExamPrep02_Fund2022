using System;
using System.Linq;

namespace P01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Done")
            {
                string[] cmdArgs = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = cmdArgs[0];

                if (action == "TakeOdd")
                {
                    password = TakeCharsFromALlOddIndices(password);
                }

                else if (action == "Cut")
                {
                    password = RemoveTheGivenSubstring(password, cmdArgs);
                }

                else if (action == "Substitute")
                {
                    password = ReplaceTheGivenSubstring(password, cmdArgs);
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
        static string TakeCharsFromALlOddIndices(string password)
        {
            char[] result = password
                .Where((symbol, index) => index % 2 != 0)
                .ToArray();
            password = string.Join("", result);
            Console.WriteLine($"{password}");

            return password;
        }


        static string RemoveTheGivenSubstring(string password, string[] cmdArgs)
        {
            int startIndex = int.Parse(cmdArgs[1]);
            int lenght = int.Parse(cmdArgs[2]);
            password = password.Remove(startIndex, lenght);

            Console.WriteLine($"{password}");

            return password;
        }

        static string ReplaceTheGivenSubstring(string password, string[] cmdArgs)
        {
            string stringToBeReplaced = cmdArgs[1];
            string substitute = cmdArgs[2];

            if (password.Contains(stringToBeReplaced))
            {
                password = password.Replace(stringToBeReplaced, substitute);

                Console.WriteLine($"{password}");
            }

            else
            {
                Console.WriteLine("Nothing to replace!");
            }

            return password;
        }
    }
}

