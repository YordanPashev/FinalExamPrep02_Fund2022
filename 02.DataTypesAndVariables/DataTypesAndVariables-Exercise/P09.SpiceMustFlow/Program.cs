using System;

namespace P09.SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startYield = int.Parse(Console.ReadLine());
            int yield = startYield;
            int days = 0;
            int totalYield = 0;

            while (yield >= 100)
            {
                totalYield += yield - 26;
                yield -= 10;
                days++;
                if (yield < 100)
                {
                    totalYield -= 26;
                    break;
                }
            }
            Console.WriteLine(days);
            Console.WriteLine(totalYield);
        }
    }
}
