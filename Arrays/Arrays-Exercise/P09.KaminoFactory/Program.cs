using System;
using System.Linq;

namespace P09.KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dnaLenght = int.Parse(Console.ReadLine());
            string currentDNA = Console.ReadLine();
            int[] bestDNAArr = new int[dnaLenght];
            int currentlongestSequence = 1;
            int longestSequence = 0;
            int lefmostStartingIndex = int.MaxValue;
            int bestSequenceSumterSum = 0;
            int currentSum = 0;
            int counter = 1;
            int bestDNASample = 0;
            int dnaIndex = 0;
            int startIndexOfSequence = 0;

            while (currentDNA != "Clone them!")
            {
                int[] arr = currentDNA
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                for (int i = 0; i < dnaLenght; i++)
                {
                    currentSum += arr[i];
                    if (i < dnaLenght - 1 && arr[i] == 1 && arr[i + 1] == 1)
                    {
                        counter++;

                        if (counter > currentlongestSequence)
                        {
                            currentlongestSequence = counter;
                            startIndexOfSequence = i;
                        }
                    }

                    else
                    {
                        counter = 1;
                    }
                }

                dnaIndex++;

                if (currentlongestSequence > longestSequence)
                {
                    longestSequence = currentlongestSequence;
                    bestSequenceSumterSum = currentSum;
                    currentlongestSequence = longestSequence;
                    lefmostStartingIndex = startIndexOfSequence;
                    bestDNASample = dnaIndex;
                    bestDNAArr = arr;
                }

                else if (startIndexOfSequence < lefmostStartingIndex)
                {
                    lefmostStartingIndex = startIndexOfSequence;
                    bestSequenceSumterSum = currentSum;
                    currentlongestSequence = longestSequence;
                    lefmostStartingIndex = startIndexOfSequence;
                    bestDNASample = dnaIndex;
                    bestDNAArr = arr;
                }

                else if (currentlongestSequence == longestSequence && 
                        startIndexOfSequence == lefmostStartingIndex &&
                        currentSum > bestSequenceSumterSum)
                {
                    bestSequenceSumterSum = currentSum;
                    currentlongestSequence = longestSequence;
                    lefmostStartingIndex = startIndexOfSequence;
                    bestDNASample = dnaIndex;
                    bestDNAArr = arr;
                }

                currentSum = 0;
                currentlongestSequence = 0;
                currentDNA = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestDNASample} with sum: {bestSequenceSumterSum}.");
            foreach (var item in bestDNAArr)
            {
                Console.Write(item + " ");
            }
        }
    }
}
