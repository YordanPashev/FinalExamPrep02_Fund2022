using System;

namespace P01.AdvertisementMessage
{
    class Program
    {

        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            string[] allPhrases = new string[]
             {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
             };

            string[] allResults = new string[]
             {
                 "Now I feel good.",
                 "I have succeeded with this product.",
                 "Makes miracles. I am happy of the results!",
                 "I cannot believe but now I feel awesome.",
                 "Try it yourself, I am very satisfied.",
                 "I feel great!"
             };

            string[] allAuthors = new string[]
             {
                 "Diana",
                 "Petya",
                 "Stella",
                 "Elena",
                 "Katya",
                 "Iva",
                 "Annie",
                 "Eva"
             };

            string[] allLocations = new string[]
             {
                 "Burgas",
                 "Sofia",
                 "Plovdiv",
                 "Varna",
                 "Ruse"
             };

            Random random = new Random();

            for (int i = 0; i < lines; i++)
            {
                int randomPhraeIndex = random.Next(0, allPhrases.Length);
                int randomEvetIndex = random.Next(0, allResults.Length);
                int randomAuthorIndex = random.Next(0, allAuthors.Length);
                int randomCitiIndex = random.Next(0, allLocations.Length);
                Console.WriteLine($"{allPhrases[randomPhraeIndex]} {allResults[randomEvetIndex]} {allAuthors[randomAuthorIndex]} – {allLocations[randomCitiIndex]}.");
            }
        }
    }
}

