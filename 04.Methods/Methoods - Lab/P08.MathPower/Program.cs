using System;

namespace P08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double digit = double.Parse(Console.ReadLine());
            double powerNum = double.Parse(Console.ReadLine());
            Console.WriteLine(MathPower(digit, powerNum));
        }
        static double MathPower(double digit, double power)
        {
            double result = 1;
            for (double i = 0; i < power; i++)
            {
                result *= digit;
            }
            return result;
        }
    }
}
