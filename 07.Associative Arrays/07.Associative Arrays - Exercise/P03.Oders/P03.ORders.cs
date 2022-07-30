using System;
using System.Linq;
using System.Collections.Generic;

namespace P04.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<decimal, int>> listOfProducts = new Dictionary<string, Dictionary<decimal, int>>();

            string cmd;

            while ((cmd = Console.ReadLine()) != "buy")
            {
                string[] cmdArgs = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string currProductName = cmdArgs[0];
                decimal currProductPrice = decimal.Parse(cmdArgs[1]);
                int currProductQuanitty = int.Parse(cmdArgs[2]);

                Dictionary<decimal, int> currProductInfo = new Dictionary<decimal, int>();
                currProductInfo.Add(currProductPrice, currProductQuanitty);

                if (!listOfProducts.ContainsKey(currProductName))
                {
                    listOfProducts.Add(currProductName, currProductInfo);
                }

                else
                {
                    ChangePriceAndAddQuantity(listOfProducts, currProductName, currProductPrice, currProductQuanitty);
                }
            }

            DisplayAllProductTotalPrices(listOfProducts);

        }

        static void DisplayAllProductTotalPrices(Dictionary<string, Dictionary<decimal, int>> ListOfProducts)
        {
            foreach (var product in ListOfProducts)
            {
                Dictionary<decimal, int> currProductValues = new Dictionary<decimal, int>();
                currProductValues = ListOfProducts[product.Key];
                foreach (var kvp in currProductValues)
                {
                    decimal totalPrice = kvp.Key * kvp.Value;
                    Console.WriteLine($"{product.Key} -> {totalPrice:F2}");

                }
            }
        }

        static void ChangePriceAndAddQuantity(Dictionary<string, Dictionary<decimal, int>> listOfProducts,
                                              string currProductName, decimal currProductPrice, int currProductQuanitty)
        {
            Dictionary<decimal, int> overWritedPorudctInfo = listOfProducts[currProductName];
            decimal oldProductPrice = 0;

            foreach (var value in overWritedPorudctInfo)
            {
                oldProductPrice = value.Key;
            }

            int addQuanitityResult = listOfProducts[currProductName][oldProductPrice] += currProductQuanitty;
            Dictionary<decimal, int> newPriceAndSumQuantity = new Dictionary<decimal, int>()
            { 
                {currProductPrice, addQuanitityResult }
            };

            listOfProducts[currProductName] = newPriceAndSumQuantity;
        }
    }
}
