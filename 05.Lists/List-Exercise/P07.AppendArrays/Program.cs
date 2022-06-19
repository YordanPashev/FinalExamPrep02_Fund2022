using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split('|');
            List<int> finalResult = new List<int>();

            for (int array = input.Length - 1; array >= 0; array--)
            {
                int[] currentArray = input[array]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                List<int> currentArrayResult = new List<int>();

                for (int currentArrayIndex = 0; currentArrayIndex < currentArray.Length; currentArrayIndex++)
                {
                    currentArrayResult.Add(currentArray[currentArrayIndex]);
                }

                finalResult.AddRange(currentArrayResult);
            }

            Console.WriteLine(string.Join(" ", finalResult));

        }
    }
}
