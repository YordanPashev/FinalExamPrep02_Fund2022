using System;

namespace P08.BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantituOfKegs = int.Parse(Console.ReadLine());
            double biggestKegVolume = int.MinValue;
            string biggestKegModel = string.Empty;
            for (int i = 1; i <= quantituOfKegs; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;
                if (volume > biggestKegVolume)
                {
                    biggestKegVolume = volume;
                    biggestKegModel = model;
                }
            }
            Console.WriteLine(biggestKegModel);
        }
    }
}
