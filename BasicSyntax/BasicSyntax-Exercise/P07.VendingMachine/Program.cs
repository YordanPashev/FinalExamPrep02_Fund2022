using System;

namespace P07.VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var totalMoney = 0.0;

            var inputCoins = Console.ReadLine();
            while (inputCoins != "Start")
            {
                var coin = double.Parse(inputCoins);
                if (coin == 0.1 ||
                    coin == 0.2 ||
                    coin == 0.5 ||
                    coin == 1 ||
                    coin == 2)
                {
                    totalMoney += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                inputCoins = Console.ReadLine();
            }

            string productName = Console.ReadLine();
            while (productName != "End")
            {
                switch (productName)
                {
                    case "Nuts":
                        if (totalMoney < 2)
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        else
                        {
                            totalMoney -= 2;
                            Console.WriteLine($"Purchased {productName.ToLower()}");
                            break;
                        }
                    case "Water":
                        if (totalMoney < 0.7)
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        else
                        {
                            totalMoney -= 0.7;
                            Console.WriteLine($"Purchased {productName.ToLower()}");
                            break;
                        }
                    case "Crisps":
                        if (totalMoney < 1.5)
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        else
                        {
                            totalMoney -= 1.5;
                            Console.WriteLine($"Purchased {productName.ToLower()}");
                            break;
                        }
                    case "Soda":
                        if (totalMoney < 0.8)
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        else
                        {
                            totalMoney -= 0.8;
                            Console.WriteLine($"Purchased {productName.ToLower()}");
                            break;
                        }
                    case "Coke":
                        if (totalMoney < 1)
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        else
                        {
                            totalMoney -= 1;
                            Console.WriteLine($"Purchased {productName.ToLower()}");
                            break;
                        }
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
                productName = Console.ReadLine();
            }
            Console.WriteLine($"Change: {totalMoney:F2}");
        }
    }
}
