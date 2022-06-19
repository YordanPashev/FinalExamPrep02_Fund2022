using System;
using System.Collections.Generic;

namespace P01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOFWagons = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToList();

            int maxCapacityPerWagon = int.Parse(Console.ReadLine());
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (cmdArgs[0] == "Add")
                {
                    int numberOFPassengersInTheNewWagon = int.Parse(cmdArgs[1]);
                    listOFWagons.Add(numberOFPassengersInTheNewWagon);
                }

                else
                {
                    int numberOFPassengersToAddInExistingWagon = int.Parse(cmdArgs[0]);

                    for (int i = 0; i < listOFWagons.Count; i++)
                    {

                        if (listOFWagons[i] + numberOFPassengersToAddInExistingWagon <= maxCapacityPerWagon)
                        {
                            listOFWagons[i] += numberOFPassengersToAddInExistingWagon;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", listOFWagons));
        }
    }
}
