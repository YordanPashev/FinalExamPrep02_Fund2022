using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.StoreBoxes
{
    class Box
    {
        public string SerialNumber { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPriceOfTheBox { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            List<Box> listOfBoxes = new List<Box>();
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();

                string serialNumber = data[0];
                string ItemName = data[1];
                int quantity = int.Parse(data[2]);
                decimal priceForSingleItem = decimal.Parse(data[3]);
                decimal totalPriceOfTheBox = priceForSingleItem * quantity;

                Box currentBoxSpecifications = new Box()
                {
                    SerialNumber = serialNumber,
                    ItemName = ItemName,
                    Quantity = quantity,
                    Price = priceForSingleItem,
                    TotalPriceOfTheBox = totalPriceOfTheBox
                };

                listOfBoxes.Add(currentBoxSpecifications);
            }

            List<Box> result = listOfBoxes.OrderBy(i => i.TotalPriceOfTheBox).ToList();
            result.Reverse();

            foreach (var box in result)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.ItemName} - ${box.Price:F2}: {box.Quantity}");
                Console.WriteLine($"-- ${(box.TotalPriceOfTheBox):F2}");
            }
        }
    }
}
