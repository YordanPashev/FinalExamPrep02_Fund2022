using System;

namespace P06.TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            char end = (char)(count + 96);
            for (char i = 'a'; i <= end; i++)
            {
                for (char j = 'a'; j <= end; j++)
                {
                    for (char k = 'a'; k <= end; k++)
                    {
                        Console.WriteLine($"{i}{j}{k}");
                    }
                }
            }
        }
    }
}
