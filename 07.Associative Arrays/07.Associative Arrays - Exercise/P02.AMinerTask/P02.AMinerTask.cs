using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] Args)
        {
            string cmd;
            Dictionary<string, long> listOfItems = new Dictionary<string, long>();


            while ((cmd = Console.ReadLine()) != "stop")
            {

                string source = cmd;
                int quantity = int.Parse(Console.ReadLine());

                    if (listOfItems.ContainsKey(source))
                    {
                        listOfItems[source] += quantity;
                    }

                    else
                    {
                        listOfItems.Add(source, quantity);
                    }

            }


            foreach (var item in listOfItems)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}