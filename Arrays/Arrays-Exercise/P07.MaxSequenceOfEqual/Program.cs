using System;
using System.Linq;

namespace P07.MaxSequenceOfEqual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int longestSequence = 0;
            int counter = 1;
            int digit = 0;
            if (arr.Length == 1)
            {
                Console.WriteLine(arr[0]);
                return;
            }
            else
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] == arr[i + 1])
                    {
                        counter++;
                        if (counter > longestSequence)
                        {
                            longestSequence = counter;
                            digit = arr[i];
                        }
                    }
                    else
                    {
                        counter = 1;
                    }
                }
            for (int i = 1; i <= longestSequence; i++)
            {
                Console.Write(digit + " ");
            }

        }
    }
}
