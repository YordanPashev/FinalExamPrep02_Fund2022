using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Product
    {

        public Product(string name, decimal price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> validProducts = new List<Product>();

            string datePattern = @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";

            Regex purchasePattern = new Regex(datePattern);

            string product;
            while ((product = Console.ReadLine()) != "Purchase")
            {
                if (purchasePattern.IsMatch(product))
                {
                    Match validProductArgs = purchasePattern.Match(product);

                    string name = validProductArgs.Groups["name"].Value;
                    decimal price = decimal.Parse(validProductArgs.Groups["price"].Value);
                    int quantity = int.Parse(validProductArgs.Groups["quantity"].Value);

                    Product productData = new Product(name, price, quantity);
                    validProducts.Add(productData);
                }
            }

            decimal totalSum = 0;
            Console.WriteLine("Bought furniture:");

            if (validProducts.Count == 0)
            {
                Console.WriteLine($"Total money spend: {totalSum:F2}");

            }

            else
            {
                foreach (var currProduct in validProducts)
                {

                    totalSum += currProduct.Price * currProduct.Quantity;
                    Console.WriteLine($"{currProduct.Name}");
                }

                Console.WriteLine($"Total money spend: {totalSum:F2}");
            }
        }
    }
}