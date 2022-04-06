using System;

namespace P02.Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var digit = int.Parse(Console.ReadLine());
            if (digit % 2 != 0 &&
                digit % 3 != 0 &&
                digit % 6 != 0 &&
                digit % 7 != 0 &&
                digit % 10 != 0)
            {
                Console.WriteLine("Not divisible");
            }
            else if (digit % 10 == 0)
            {
                Console.WriteLine("The number is divisible by 10");
            }
            else if (digit % 7 == 0)
            {
                Console.WriteLine("The number is divisible by 7");
            }
            else if (digit % 6 == 0)
            {
                Console.WriteLine("The number is divisible by 6");
            }
            else if (digit % 3 == 0)
            {
                Console.WriteLine("The number is divisible by 3");
            }
            else if (digit % 2 == 0)
            {
                Console.WriteLine("The number is divisible by 2");
            }
        }
    }
}
