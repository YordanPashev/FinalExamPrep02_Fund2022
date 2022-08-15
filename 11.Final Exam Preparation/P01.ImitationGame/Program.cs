using System;
using System.Linq;

namespace P01.ImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Decode")
            {
                string[] cmdArgs = cmd
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = cmdArgs[0];

                if (action == "Move")
                {
                    message = MoveFirstLetterToTheBack(message, cmdArgs);
                }

                else if (action == "Insert")
                {
                    message = InsertGivenValueOnIndex(message, cmdArgs);
                }

                else if (action == "ChangeAll")
                {
                    message = ReplaceGivenSubstring(message, cmdArgs);
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }

        static string MoveFirstLetterToTheBack(string messgae, string[] cmdArgs)
        {
            int numberOfLetter = int.Parse(cmdArgs[1]);
            string sbstringToMove = messgae.Substring(0, numberOfLetter);
            messgae = messgae.Remove(0, numberOfLetter);

            return messgae + sbstringToMove;

        }

        static string InsertGivenValueOnIndex(string messgae, string[] cmdArgs)
        {
            int index = int.Parse(cmdArgs[1]);
            string value = cmdArgs[2];

            return messgae.Insert(index, value);
        }

        static string ReplaceGivenSubstring(string messgae, string[] cmdArgs)
        {
            string oldSubstring = cmdArgs[1];
            string newSubstring = cmdArgs[2];

            return messgae.Replace(oldSubstring, newSubstring);
        }
    }
}
