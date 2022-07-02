using System;

namespace P11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            for (int i = 1; i <= orders; i++)
            {
                double capsuleSinglePrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                double capsuleCount = double.Parse(Console.ReadLine());
                double priceOfOrder = (days * capsuleCount) * capsuleSinglePrice;
                Console.WriteLine($"The price for the coffee is: ${priceOfOrder:F2}");
                totalPrice += priceOfOrder;
            }
            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
