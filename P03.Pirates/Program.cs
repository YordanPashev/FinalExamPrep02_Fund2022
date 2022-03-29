using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace P03.Pirates
{
    class Program
    {
        class City
        {
            public City(string name, int population, int gold)
            {
                this.Name = name;
                this.Population = population;
                this.Gold = gold;
            }
            public string Name { get; set; }
            public int Population { get; set; }
            public int Gold { get; set; }
        }
        static void Main(string[] args)
        {
            List<City> listOfTargets = new List<City>();
            string target;

            while ((target = Console.ReadLine()) != "Sail")
            {
                AddTargetsInfo(target, listOfTargets);
            }

            string currEvent;
            while ((currEvent = Console.ReadLine()) != "End")
            {
                string[] eventArgs = currEvent
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string eventType = eventArgs[0];

                if (eventType == "Plunder")
                {
                    Plunder(eventArgs, listOfTargets);
                }

                else if (eventType == "Prosper")
                {
                    Prosper(eventArgs, listOfTargets);
                }
            }

            DisplayAllExistingSettlements(listOfTargets);
        }

        static void AddTargetsInfo(string currTarget, List<City> listOfTargets)
        {
            string[] targetArgs = currTarget
                            .Split("||", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            string name = targetArgs[0];
            int population = int.Parse(targetArgs[1]);
            int gold = int.Parse(targetArgs[2]);

            if (!listOfTargets.Any(x => x.Name == name))
            {
                City newCityToAdd = new City(name, population, gold);
                listOfTargets.Add(newCityToAdd);
            }

            else
            {
                int index = listOfTargets.FindIndex(x => x.Name == name);
                listOfTargets[index].Population += population;
                listOfTargets[index].Gold += gold;
            }
        }

        static void Plunder(string[] eventArgs, List<City> listOfTargets)
        {
            string nameOfTheTown = eventArgs[1];
            int killedCitizents = int.Parse(eventArgs[2]);
            int stolenGold = int.Parse(eventArgs[3]);

            int index = listOfTargets.FindIndex(x => x.Name == nameOfTheTown);
            listOfTargets[index].Population -= killedCitizents;
            listOfTargets[index].Gold -= stolenGold;
            Console.WriteLine($"{nameOfTheTown} plundered! {stolenGold} gold stolen, {killedCitizents} citizens killed.");

            if (listOfTargets[index].Gold <= 0 || listOfTargets[index].Population <= 0)
            {
                listOfTargets.RemoveAt(index);
                Console.WriteLine($"{nameOfTheTown} has been wiped off the map!");
            }
        }
        static void Prosper(string[] eventArgs, List<City> listOfTargets)
        {
            string nameOfTheTown = eventArgs[1];
            int goldToAdd = int.Parse(eventArgs[2]);

            if (goldToAdd < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
            }

            else
            {
                int index = listOfTargets.FindIndex(x => x.Name == nameOfTheTown);
                listOfTargets[index].Gold += goldToAdd;
                int totalGoldinTheTown = listOfTargets[index].Gold;

                Console.WriteLine($"{goldToAdd} gold added to the city treasury. {nameOfTheTown} now has {totalGoldinTheTown} gold.");
            }

        }

        static void DisplayAllExistingSettlements(List<City> listOfTargets)
        {
            if (listOfTargets.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {listOfTargets.Count} wealthy settlements to go to:");

                foreach (var town in listOfTargets)
                {
                    Console.WriteLine($"{town.Name} -> Population: {town.Population} citizens, Gold: {town.Gold} kg");
                }
                Console.WriteLine();
            }

            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }

        }
    }
}