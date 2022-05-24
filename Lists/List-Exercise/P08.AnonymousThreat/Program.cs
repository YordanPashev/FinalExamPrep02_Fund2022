using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "3:1")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = cmdArgs[0];


                if (action == "merge")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    list = MergeElements(list, startIndex, endIndex);
                }

                else if (action == "divide")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int partitions = int.Parse(cmdArgs[2]);

                    list = DevideElements(list, index, partitions);
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }

        static List<string> MergeElements(List<string> list, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex > list.Count - 1)
            {
                endIndex = list.Count - 1;
            }

            for (int numberOfMerges = startIndex + 1; numberOfMerges <= endIndex; numberOfMerges++)
            {
                list[startIndex] += list[startIndex + 1];
                list.RemoveAt(startIndex + 1);
            }

            return list;
        }

        static List<string> DevideElements(List<string> list, int index, int partitions)
        {
            List<char> allElementsInCurrIndex = list[index].ToList();
            int elementsInOnePartition = allElementsInCurrIndex.Count / partitions;

            if (elementsInOnePartition == 0)
            {
                elementsInOnePartition = allElementsInCurrIndex.Count / (list.Count - index);
            }

            list.RemoveAt(index);

            for (int partitionNumber = 0; partitionNumber < partitions; partitionNumber++)
            {
                StringBuilder currentPartiton = new StringBuilder();

                if (allElementsInCurrIndex.Count == 0)
                {
                    break;
                }

                if (partitionNumber == partitions - 1)
                {
                    currentPartiton.Append(string.Join("", allElementsInCurrIndex));
                    allElementsInCurrIndex.RemoveRange(0, allElementsInCurrIndex.Count);
                    list.Insert(index + partitionNumber, currentPartiton.ToString());
                    break;
                }

                for (int charIndex = 0; charIndex < elementsInOnePartition; charIndex++)
                {
                    currentPartiton.Append(allElementsInCurrIndex[charIndex]);
                }

                list.Insert(index + partitionNumber, currentPartiton.ToString());
                allElementsInCurrIndex.RemoveRange(0, elementsInOnePartition);
            }

            return list;
        }
    }
}