using System;

namespace P01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arrayOfWords = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Random random = new Random();

            for (int i = 0; i < arrayOfWords.Length; i++)
            {
                int randomIndex = random.Next(0, arrayOfWords.Length);
                string currentWord = arrayOfWords[i];
                arrayOfWords[i] = arrayOfWords[randomIndex];
                arrayOfWords[randomIndex] = currentWord;
            }

            foreach (var word in arrayOfWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
