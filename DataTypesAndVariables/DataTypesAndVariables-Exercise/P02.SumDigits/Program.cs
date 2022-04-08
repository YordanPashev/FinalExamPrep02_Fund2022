using System;

namespace P02.SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int numLeft = input;
            int sum = 0;

            while (numLeft != 0)
            {
                int currentNum = numLeft % 10;
                sum += currentNum;
                numLeft /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}