using System;
using System.Linq;

namespace P06.EvenAndOddSubtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] digits = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int evenSum = 0;
            int oddSum = 0;

            foreach (var currectNum in digits)
            {
                if (currectNum % 2 == 0)
                {
                    evenSum += currectNum;
                }
                else
                {
                    oddSum += currectNum;
                }
            }
            Console.WriteLine(evenSum - oddSum);
        }
    }
}
