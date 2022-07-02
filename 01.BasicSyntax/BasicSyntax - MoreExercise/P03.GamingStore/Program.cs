using System;

namespace P03.GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            string gameName = Console.ReadLine();
            double gamePrice = 0, totalPrice = 0;
            while (gameName != "Game Time" && currentBalance > 0)
            {
                switch (gameName)
                {
                    case "OutFall 4":
                        gamePrice = 39.99;
                        if (currentBalance >= gamePrice)
                        {
                            Console.WriteLine($"Bought {gameName}");
                            currentBalance -= gamePrice;
                            totalPrice += gamePrice;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "CS: OG":
                        gamePrice = 15.99;
                        if (currentBalance >= gamePrice)
                        {
                            Console.WriteLine($"Bought {gameName}");
                            currentBalance -= gamePrice;
                            totalPrice += gamePrice;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Zplinter Zell":
                        gamePrice = 19.99;
                        if (currentBalance >= gamePrice)
                        {
                            Console.WriteLine($"Bought {gameName}");
                            currentBalance -= gamePrice;
                            totalPrice += gamePrice;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Honored 2":
                        gamePrice = 59.99;
                        if (currentBalance >= gamePrice)
                        {
                            Console.WriteLine($"Bought {gameName}");
                            currentBalance -= gamePrice;
                            totalPrice += gamePrice;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch":
                        gamePrice = 29.99;
                        if (currentBalance >= gamePrice)
                        {
                            Console.WriteLine($"Bought {gameName}");
                            currentBalance -= gamePrice;
                            totalPrice += gamePrice;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch Origins Edition":
                        gamePrice = 39.99;
                        if (currentBalance >= gamePrice)
                        {
                            Console.WriteLine($"Bought {gameName}");
                            currentBalance -= gamePrice;
                            totalPrice += gamePrice;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }
                gameName = Console.ReadLine();
            }
            if (currentBalance == 0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${totalPrice:F2}. Remaining: ${currentBalance:F2}");
            }
        }
    }
}

