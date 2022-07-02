using System;

namespace P03.ExactSumOfRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            decimal reslult = 0M;
            for (int i = 1; i <= quantity; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                reslult += number;
            }
            Console.WriteLine(reslult);
        }
    }
}
