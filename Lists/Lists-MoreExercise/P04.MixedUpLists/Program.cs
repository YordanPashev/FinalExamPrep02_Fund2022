using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.MixedUpLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOne = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> listTwo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] range = GetRangeValuesAndRemoveThemFromTheList(listOne, listTwo);
            Array.Sort(range);

            int minIndexVAlue = range[0];
            int maxIndexVAlue = range[1];

            List<int> result = MixUpTwoLists(listOne, listTwo);
            result.RemoveAll(x => x >= maxIndexVAlue || x <= minIndexVAlue);

            result.Sort();
            Console.WriteLine(string.Join(" ", result));
        }

        static int[] GetRangeValuesAndRemoveThemFromTheList(List<int> listOne, List<int> listTwo)
        {
            if (listOne.Count > listTwo.Count)
            {
                int[] rangeValues = new int[2]
                {
                  listOne[listOne.Count - 1],
                  listOne[listOne.Count - 2]
                };
                listOne.RemoveRange(listOne.Count - 2, 2);

                return rangeValues;
            }

            else
            {
                int[] rangeValues = new int[2]
                {
                  listTwo[0],
                  listTwo[1]
                };

                listTwo.RemoveRange(0, 2);

                return rangeValues;
            }
        }

        static List<int> MixUpTwoLists(List<int> listOne, List<int> listTwo)
        {
            listTwo.Reverse();
            int secondListIndex = 0;
            List<int> result = listOne;

            for (int firstListIndex = 0; firstListIndex <= listOne.Count; firstListIndex++)
            {
                if (firstListIndex % 2 != 0)
                {
                    result.Insert(firstListIndex, listTwo[secondListIndex]);
                    secondListIndex++;
                }
            }

            return result;
        }
    }
}
