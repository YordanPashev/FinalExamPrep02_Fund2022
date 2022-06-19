using System;
using System.Linq;

namespace P03.Zig_ZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int lineCounter = 0;

            int[] arr1 = new int[lines];
            int[] arr2 = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                lineCounter++;

                if (lineCounter % 2 == 0)
                {
                    arr2[i] = input[0];
                    arr1[i] = input[1];
                }
                else
                {
                    arr1[i] = input[0];
                    arr2[i] = input[1];
                }
            }

            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}
