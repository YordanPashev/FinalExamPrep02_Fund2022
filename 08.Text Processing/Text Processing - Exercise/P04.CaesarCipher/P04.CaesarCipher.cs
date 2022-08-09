using System;
using System.Text;

namespace CeaserCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedText = Console.ReadLine();
            StringBuilder result = new StringBuilder();

            foreach (char ch in encryptedText)
            {
                int charValueResult = ch + 3;
                result.Append((char)charValueResult);
            }

            Console.WriteLine(result);
        }
    }
}