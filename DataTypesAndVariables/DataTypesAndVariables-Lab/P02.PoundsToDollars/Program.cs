using System;

namespace P02.PoundsToDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            decimal result = pounds * 1.31m;
            Console.WriteLine($"{result:F3}");
        }
    }
}

