using System;

namespace P01.ExtractPersonInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfLines; i++)
            {
                string currSentence = Console.ReadLine();

                string name = ExtractTheNameFromCurrSentence(currSentence);
                string age = ExtractTheAgeFromCurrSentence(currSentence);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }

        static string ExtractTheNameFromCurrSentence(string currSentence)
        {
            int nameStartIndex = currSentence.IndexOf('@') + 1;
            int nameLastIndex = currSentence.IndexOf('|');
            int nameLenght = nameLastIndex - nameStartIndex;
            return currSentence.Substring(nameStartIndex, nameLenght);
        }

        static string ExtractTheAgeFromCurrSentence(string currSentence)
        {
            int nameStartIndex = currSentence.IndexOf('#') + 1;
            int nameLastIndex = currSentence.IndexOf('*');
            int ageDigits = nameLastIndex - nameStartIndex;
            return currSentence.Substring(nameStartIndex, ageDigits);
        }
    }
}