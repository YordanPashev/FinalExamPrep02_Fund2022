using System;

namespace P01.ConvertMetersToKilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal meters = int.Parse(Console.ReadLine());
            decimal kilometers = meters / 1000m;
            Console.WriteLine($"{kilometers:F2}");
        }
    }
}

