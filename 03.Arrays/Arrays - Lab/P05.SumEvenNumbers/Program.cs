using System;
using System.Linq;

namespace P05.SumEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] digits = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int totalSum = 0;
            foreach (var item in digits)
            {
                if (item % 2 == 0)
                {
                    totalSum += item;
                }
            }
            Console.WriteLine(totalSum);
        }
    }
}

