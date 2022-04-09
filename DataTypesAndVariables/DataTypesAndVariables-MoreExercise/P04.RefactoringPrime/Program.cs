using System;

namespace P04.RefactoringPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            for (int num = 2; num <= end; num++)
            {
                bool isPrime = true;
                for (int divider = 2; divider < num; divider++)
                {
                    if (num % divider == 0 && num > 3)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    Console.WriteLine($"{num} -> true");
                }
                else
                {
                    Console.WriteLine($"{num} -> false");
                }
            }

        }
    }
}
