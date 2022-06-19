using System;
using System.Linq;

namespace P07.EqualArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool areEqual = false;
            int sum = 0;
            int index = 0;

            int[] arr1 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] arr2 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    areEqual = true;
                    sum += arr1[i];
                    continue;
                }
                else
                {
                    areEqual = false;
                    index = i;
                    break;
                }
            }

            if (areEqual)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
            }
        }
    }
}
