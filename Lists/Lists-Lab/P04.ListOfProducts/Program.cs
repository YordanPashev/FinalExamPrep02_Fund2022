using System;
using System.Collections.Generic;

namespace P04.ListOfProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            List<string> productNames = new List<string>();
            for (int i = 0; i < quantity; i++)
            {
                productNames.Add(Console.ReadLine());
            }

            productNames.Sort();

            for (int i = 1; i <= productNames.Count; i++)
            {
                Console.WriteLine($"{i}.{productNames[i - 1]}");
            }
        }
    }
}
