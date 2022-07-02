using System;

namespace P12.RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            int sum = 0;
            bool isSpacial = false;
            for (int i = 1; i <= end; i++)
            {
                int num = i;
                while (num > 0)
                {
                    int currentNum = num % 10;
                    sum += currentNum;
                    num /= 10;
                }
                isSpacial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{i} -> {isSpacial}");
                sum = 0;
            }

        }
    }
}
