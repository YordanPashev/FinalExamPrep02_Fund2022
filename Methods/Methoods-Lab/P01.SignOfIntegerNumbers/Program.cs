using System;

namespace P01.SignOfIntegerNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            PrintNumberSign(input);

        }
        static void PrintNumberSign(int input)
        {
            if (input < 0)
            {
                Console.WriteLine($"The number {input} is negative. ");
            }
            else if (input > 0)
            {
                Console.WriteLine($"The number {input} is positive. ");
            }
            else if (input == 0)
            {
                Console.WriteLine($"The number {input} is zero. ");
            }
        }
    }
}
