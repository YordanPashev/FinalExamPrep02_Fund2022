using System;

namespace P10.RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lostGamesNumber = double.Parse(Console.ReadLine());
            var headsetPrice = double.Parse(Console.ReadLine());
            var mousePrice = double.Parse(Console.ReadLine());
            var keyboardPrice = double.Parse(Console.ReadLine());
            var displayPrice = double.Parse(Console.ReadLine());
            double rageExpenses = (Math.Floor(lostGamesNumber / 2) * headsetPrice) +
                                (Math.Floor(lostGamesNumber / 3) * mousePrice) +
                                (Math.Floor(lostGamesNumber / 6) * keyboardPrice) +
                                (Math.Floor(lostGamesNumber / 12) * displayPrice);

            Console.WriteLine($"Rage expenses: {rageExpenses:F2} lv.");



        }
    }
}
