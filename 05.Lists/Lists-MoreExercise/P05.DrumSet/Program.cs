using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.DrumSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());

            List<int> drumSet = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] initialQualityValues = drumSet.ToArray();
            List<int> initialQualityList = initialQualityValues.ToList();

            string input;

            while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                DecreassTheValueOfTheDrumsQuality(drumSet, hitPower);

                if (drumSet.Any(x => x <= 0))
                {
                    for (int i = 0; i < drumSet.Count; i++)
                    {
                        if (drumSet[i] <= 0)
                        {
                            if (BuyANewDrum(i, budget, initialQualityList))
                            {
                                budget -= initialQualityList[i] * 3;
                                drumSet[i] = initialQualityList[i];
                            }

                            else
                            {
                                drumSet.RemoveAt(i);
                                initialQualityList.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {budget:F2}lv.");
        }

        static void DecreassTheValueOfTheDrumsQuality(List<int> drumSet, int hotPower)
        {
            for (int i = 0; i < drumSet.Count; i++)
            {
                drumSet[i] -= hotPower;
            }
        }

        static bool BuyANewDrum(int drumSetIndex, decimal budget, List<int> initialQualityList)
        {
            if (initialQualityList[drumSetIndex] * 3 <= budget)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
