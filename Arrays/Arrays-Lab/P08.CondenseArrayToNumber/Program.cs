using System;
using System.Linq;

namespace P08.CondenseArrayToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse).
                ToArray();

            int[] sumArray = new int[arr.Length];
            int totalSum = 0;
            int size = arr.Length;

            while (size > 1 && arr.Length > 1)
            {
                for (int i = 0; i < size - 1; i++)
                {
                    sumArray[i] = arr[i] + arr[i + 1];
                    arr[i] = sumArray[i];
                    totalSum = arr[i];
                }
                size--;
            }

            if (arr.Length > 1)
            {
                Console.WriteLine(totalSum);
            }
            else
            {
                totalSum = arr[0];
                Console.WriteLine(totalSum);
            }
        }
    }
}
