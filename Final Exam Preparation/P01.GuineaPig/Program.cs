using System;

namespace P01.GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal foodQuantity = decimal.Parse(Console.ReadLine());
            decimal hayQuantity = decimal.Parse(Console.ReadLine());
            decimal coverQuantity = decimal.Parse(Console.ReadLine());
            decimal pigsWeight = decimal.Parse(Console.ReadLine());
            decimal totalHayLoss = 0;

            //foodQuantity -= (30 * 0.3m);


            for (int day = 1; day <= 30; day++)
            {
                foodQuantity -= 0.300m;

                if (day % 2 == 0)
                {
                    totalHayLoss += foodQuantity * 0.05m;
                }
            }

            hayQuantity -= totalHayLoss;

            coverQuantity -= (pigsWeight / 3) * 10;

            if (foodQuantity > 0 && hayQuantity > 0 && coverQuantity > 0)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodQuantity:F2}, Hay: {hayQuantity:F2}, Cover: {coverQuantity:F2}.");
            }

            else
            {
                Console.WriteLine("Merry must go to the pet store!");
            }


        }
    }
}