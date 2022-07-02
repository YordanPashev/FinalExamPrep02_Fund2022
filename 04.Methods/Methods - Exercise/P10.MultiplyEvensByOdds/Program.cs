using System;

namespace P10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int resultOfEvenSum = GetSumOfEvenDigits(input);
            int resultOfOddSum = GetSumOfOddDigits(input);
            int result = resultOfEvenSum * resultOfOddSum;
            Console.WriteLine(result);
        }
        static int GetSumOfEvenDigits(int digit)
        {
            int evenSum = 0;
            while (digit != 0)
            {
                int currentDigit = Math.Abs(digit) % 10;
                if (currentDigit % 2 == 0)
                {
                    evenSum += currentDigit;
                }
                digit /= 10;
            }
            return evenSum;
        }

        static int GetSumOfOddDigits(int digit)
        {
            int oddSum = 0;
            while (digit != 0)
            {
                int currentDigit = Math.Abs(digit) % 10;
                if (currentDigit % 2 != 0)
                {
                    oddSum += currentDigit;
                }
                digit /= 10;
            }
            return oddSum;
        }
    }
}
