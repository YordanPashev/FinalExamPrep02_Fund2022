using System;

namespace P10.PokeMon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exFact = int.Parse(Console.ReadLine());
            int targets = 0;
            int energyLeft = (int)power;
            double halfEnergy = power / 2;

            while (energyLeft >= distance)
            {
                energyLeft -= distance;
                targets++;
                if (exFact > 0 &&
                    energyLeft == halfEnergy
                    && energyLeft / exFact > 0)
                    energyLeft /= exFact;
                {
                    if (energyLeft < distance)
                    {
                        break;
                    }
                }

            }

            Console.WriteLine(energyLeft);
            Console.WriteLine(targets);
        }
    }
}
