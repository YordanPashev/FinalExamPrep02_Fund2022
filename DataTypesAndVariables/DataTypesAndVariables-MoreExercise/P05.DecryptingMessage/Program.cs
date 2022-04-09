using System;
using System.Text;

namespace P05.DecryptingMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int line = int.Parse(Console.ReadLine());
            StringBuilder encryptedMessage = new StringBuilder();

            for (int i = 0; i < line; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                char encryptedChar = (char)((int)currentChar + key);
                encryptedMessage.Append(encryptedChar);
            }
            Console.WriteLine(encryptedMessage);
        }
    }
}
