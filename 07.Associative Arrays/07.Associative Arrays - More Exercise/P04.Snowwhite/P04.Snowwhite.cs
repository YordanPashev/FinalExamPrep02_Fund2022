using System;
using System.Linq;
using System.Collections.Generic;

namespace Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> dwarfList = new Dictionary<string, Dictionary<string, long>>();

            string inputData;

            while ((inputData = Console.ReadLine()) != "Once upon a time")
            {
                AddNewDwarfData(inputData, dwarfList);
            }

            DisplayAllDwarfts(dwarfList);
        }

        static void AddNewDwarfData(string inputData, Dictionary<string, Dictionary<string, long>> dwarfList)
        {
            string[] currDwarfInfo = inputData
                                .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
            string currDwarfName = currDwarfInfo[0];
            string hatColor = currDwarfInfo[1];
            long currDwarfPhysics = int.Parse(currDwarfInfo[2]);

            if (!dwarfList.ContainsKey(hatColor))
            {
                Dictionary<string, long> currDwarfNameAndPhysic = new Dictionary<string, long>();

                currDwarfNameAndPhysic.Add(currDwarfName, currDwarfPhysics);
                dwarfList.Add(hatColor, currDwarfNameAndPhysic);
            }

            else if (dwarfList.ContainsKey(hatColor))
            {
                if (!dwarfList[hatColor].ContainsKey(currDwarfName))
                {
                    Dictionary<string, long> currDwarfNameAndPhysic = new Dictionary<string, long>();

                    currDwarfNameAndPhysic.Add(currDwarfName, currDwarfPhysics);
                    dwarfList[hatColor].Add(currDwarfName, currDwarfPhysics);
                }

                else
                {
                    if (currDwarfPhysics > dwarfList[hatColor][currDwarfName])
                    {
                        dwarfList[hatColor][currDwarfName] = currDwarfPhysics;
                    }
                }
            }
        }

        static void DisplayAllDwarfts(Dictionary<string, Dictionary<string, long>> dwarfList)
        {
            Dictionary<string, long> result = new Dictionary<string, long>();

            foreach (var hatColor in dwarfList.OrderByDescending(x => x.Value.Count()))
            {
                foreach (var dwarf in hatColor.Value)
                {
                    string currHatColor = hatColor.Key;
                    string currDwarf = dwarf.Key;
                    long physic = dwarf.Value;
                    result.Add($"({currHatColor}) {currDwarf}", physic);
                }
            }

            foreach (var dwarf in result.OrderByDescending(dw => dw.Value))
            {
                string dwarfHatColorAndName = dwarf.Key;
                long dwarfPhysics = dwarf.Value;
                Console.WriteLine($"{dwarfHatColorAndName} <-> {dwarfPhysics}");
            }
        }
    }
}