using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.PlantDiscovery
{
    internal class Program
    {
        class Plant 
        {
            public Plant(string name, int rarity)
            {
                this.Name = name;
                this.Rarity = rarity;
            }
            public Plant(string name, int rarity, int raiting, int raitingItterations)
            {
                this.Name = name;
                this.Rarity = rarity;
                this.Raiting = raiting;
                this.RaitingCounter = raitingItterations;
            }
            public string Name { get; set; }

            public int Rarity { get; set; }

            public int Raiting { get; set; }

            public int RaitingCounter { get; set; }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Plant> listOfAllPlants = new Dictionary<string, Plant>();

            int numberOfLine = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLine; i++)
            {
                string[] plantInfo = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                AddCurrPlantAndHisRarity(plantInfo, listOfAllPlants);
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "Exhibition")
            {
                string[] cmdArgs = cmd
                    .Split(new char[] { ':', '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();
                string currPlantName = cmdArgs[1].Trim();

                if (listOfAllPlants.ContainsKey(currPlantName))
                {
                    ExecuteTheCmd(cmdArgs, currPlantName, listOfAllPlants);
                }

                else
                {
                    Console.WriteLine("error");
                }
            }

            DisplayAllPlantsInfo(listOfAllPlants);
        }

        static void AddCurrPlantAndHisRarity(string[] plantInfo, Dictionary<string, Plant> listOfAllPlants)
        {
            string nameToAdd = plantInfo[0];
            int rarity = int.Parse(plantInfo[1]);

            if (listOfAllPlants.ContainsKey(nameToAdd))
            {
                listOfAllPlants[nameToAdd].Rarity = rarity;
            }

            else
            {
                List<int> currPlatSpecifications = new List<int>();
                int rating = 0;
                int raitingCOunter = 0;
                Plant currPlantInfo = new Plant(nameToAdd, rarity, rating, raitingCOunter);
                listOfAllPlants.Add(nameToAdd, currPlantInfo);
            }
        }

        static void ExecuteTheCmd(string[] cmdArgs, string currPlantName, Dictionary<string, Plant> listOfAllPlants)
        {
            string action = cmdArgs[0].Trim();

            if (action == "Rate")
            {
                int raiting = int.Parse(cmdArgs[2]);
                listOfAllPlants[currPlantName].Raiting += raiting;
                listOfAllPlants[currPlantName].RaitingCounter += 1;
            }

            else if (action == "Update")
            {
                int rarity = int.Parse(cmdArgs[2]);
                listOfAllPlants[currPlantName].Rarity = rarity;
            }

            else if (action == "Reset")
            {
                listOfAllPlants[currPlantName].Raiting = 0;
                listOfAllPlants[currPlantName].RaitingCounter = 0;
            }
        }

        static void DisplayAllPlantsInfo(Dictionary<string, Plant> listOfAllPlants)
        {
            double averageRaiting = 0;

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in listOfAllPlants)
            {
                string plantName = plant.Key;
                int rarity = plant.Value.Rarity;
                double totalRaitingSum = plant.Value.Raiting;
                double totalRaitingCount = plant.Value.RaitingCounter;

                if (totalRaitingCount != 0 || totalRaitingSum != 0)
                {
                    averageRaiting = totalRaitingSum / totalRaitingCount;

                }

                Console.WriteLine($" - {plantName}; Rarity: {rarity}; Rating: {averageRaiting:F2}");
            }
        }
    }
}

