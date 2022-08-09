using System;
using System.Linq;

namespace ExtractFIle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            string[] pathConcertToArray = inputLine
                .Split("\\", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string result = pathConcertToArray[pathConcertToArray.Length - 1];
            int dotIndex = result.LastIndexOf('.');
            string extension = result.Substring(dotIndex + 1);
            string fileName = result.Substring(0, dotIndex);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}