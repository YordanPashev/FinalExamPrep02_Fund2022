using System;

namespace P08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstDigit = int.Parse(Console.ReadLine());
            int secondDigit = int.Parse(Console.ReadLine());
            decimal firstResult = CalculateFactorial(firstDigit);
            decimal secondResult = CalculateFactorial(secondDigit);
            DivideFactorialsResult(firstResult, secondResult);
        }
        static decimal CalculateFactorial(int digit)
        {
            decimal result = digit;
            for (int i = digit - 1; i > 1; i--)
            {
                result *= i;
            }
            return result;
        }
        static void DivideFactorialsResult(decimal resultOne, decimal resultTwo)
        {
            decimal finalResult = resultOne / resultTwo;
            Console.WriteLine($"{finalResult:F2}");
        }
    }
}
