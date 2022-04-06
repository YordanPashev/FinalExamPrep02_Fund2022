using System;
using System.Text;

namespace P05.Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int messageLenght = int.Parse(Console.ReadLine());
            StringBuilder message = new StringBuilder();
            for (int i = 1; i <= messageLenght; i++)
            {
                string input = Console.ReadLine();
                char main = (input[0]);
                int mainNumber = main - 48;
                if (mainNumber == 0)
                {
                    char letter = (char)32;
                    message.Append(letter);
                }
                else if (mainNumber != 8 &&
                    mainNumber != 9)
                {
                    int offset = (mainNumber - 2) * 3;
                    int indexLetter = (offset + input.Length - 1) + 97;
                    char letter = (char)indexLetter;
                    message.Append(letter);
                }
                else
                {
                    int offset = ((mainNumber - 2) * 3) + 1;
                    int indexLetter = (offset + input.Length - 1) + 97;
                    char letter = (char)indexLetter;
                    message.Append(letter);
                }
            }
            Console.WriteLine(message);
        }
    }
}
