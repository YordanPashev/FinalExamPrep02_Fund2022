using System;
using System.Numerics;

namespace P02.BigFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            BigInteger factorialResult = 1;

            for (int i = number; i >= 2; i--)
            {
                factorialResult *= i;
            }

            Console.WriteLine(factorialResult);
        }
    }
}
