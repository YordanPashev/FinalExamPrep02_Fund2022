using System;
using System.Linq;

namespace P03.RoudingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] digits = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            int[] round = new int[digits.Length];

            for (int j = 0; j < digits.Length; j++)
            {
                Console.WriteLine($"{Convert.ToDecimal(digits[j])} => {Convert.ToDecimal(Math.Round(digits[j], MidpointRounding.AwayFromZero))}");
            }
        }
    }
}