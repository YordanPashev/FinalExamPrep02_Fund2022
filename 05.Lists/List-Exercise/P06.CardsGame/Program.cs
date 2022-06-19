using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPleayersDeck = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondPleayersDeck = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();

            while (firstPleayersDeck.Count > 0 && secondPleayersDeck.Count > 0)
            {

                if (firstPleayersDeck[0] == secondPleayersDeck[0])
                {
                    firstPleayersDeck.RemoveAt(0);
                    secondPleayersDeck.RemoveAt(0);
                }

                else if (firstPleayersDeck[0] > secondPleayersDeck[0])
                {
                    firstPleayersDeck.Add(firstPleayersDeck[0]);
                    firstPleayersDeck.RemoveAt(0);
                    firstPleayersDeck.Add(secondPleayersDeck[0]);
                    secondPleayersDeck.RemoveAt(0);
                }

                else if (firstPleayersDeck[0] < secondPleayersDeck[0])
                {
                    secondPleayersDeck.Add(secondPleayersDeck[0]);
                    secondPleayersDeck.RemoveAt(0);
                    secondPleayersDeck.Add(firstPleayersDeck[0]);
                    firstPleayersDeck.RemoveAt(0);
                }
            }

            if (firstPleayersDeck.Count > 0)
            {
                int totalSum = firstPleayersDeck.Sum();
                Console.WriteLine($"First player wins! Sum: {totalSum}");
            }

            else
            {
                int totalSum = secondPleayersDeck.Sum();
                Console.WriteLine($"Second player wins! Sum: {totalSum}");
            }
        }
    }
}