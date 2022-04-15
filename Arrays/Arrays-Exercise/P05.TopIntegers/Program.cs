using System;
using System.Linq;

namespace P05.TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    break;
                }
                for (int j = i + 1; j <= arr.Length - 1; j++)
                {
                    if (arr[i] <= arr[j])
                    {
                        break;
                    }

                    else if (arr[i] >= arr[j] && j == arr.Length - 1)
                    {
                        Console.Write(arr[i] + " ");
                    }
                }
            }

            Console.WriteLine(arr[arr.Length - 1]);
        }
    }
}
