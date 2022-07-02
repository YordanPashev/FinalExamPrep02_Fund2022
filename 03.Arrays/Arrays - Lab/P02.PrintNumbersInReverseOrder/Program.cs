using System;

namespace P02.PrintNumbersInReverseOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] digits = new int[count];

            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = int.Parse(Console.ReadLine());
            }

            Array.Reverse(digits);

            foreach (var item in digits)
            {
                Console.Write(item + " ");
            }
        }
    }
}
