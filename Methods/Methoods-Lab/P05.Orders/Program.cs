using System;

namespace P05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            Calculate(product, amount);
        }

        static void Calculate(string product, int amount)
        {
            double result = 0;
            string productName = product;
            switch (product)
            {
                case "coffee":
                    result = amount * 1.5;
                    break;

                case "water":
                    result = amount * 1;
                    break;

                case "coke":
                    result = amount * 1.4;
                    break;

                case "snacks":
                    result = amount * 2;
                    break;
            }
            Console.WriteLine($"{result:f2}");
        }
    }
}
