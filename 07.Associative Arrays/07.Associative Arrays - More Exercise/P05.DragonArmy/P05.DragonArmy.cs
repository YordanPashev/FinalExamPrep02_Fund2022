using System;
using System.Linq;
using System.Collections.Generic;

namespace DragonArmy
{
    class Dragon
    {
        public Dragon(string type, string name, int damage, int health, int armor)
        {
            this.Type = type;
            this.Name = name;
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }

        public string Type { get; set; }

        public string Name { get; set; }

        public int Damage { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dragon> dragonList = new List<Dragon>();
            int numberOfDragons = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfDragons; i++)
            {
                string[] dragonSpecifications = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                AddDragon(dragonSpecifications, dragonList);
            }

            DisplayAllDragons(dragonList);
        }

        static void AddDragon(string[] dragonSpecifications, List<Dragon> dragonList)
        {
            string currDragonType = dragonSpecifications[0];
            string currDragonName = dragonSpecifications[1];

            AddDefaultVAluesIfThereIsANullInout(dragonSpecifications);

            int currDragonDamage = int.Parse(dragonSpecifications[2]);
            int currDragonHealth = int.Parse(dragonSpecifications[3]);
            int currDragonArmor = int.Parse(dragonSpecifications[4]);

            if (dragonList.Any(dr => dr.Type == currDragonType))
            {
                for (int i = 0; i < dragonList.Count; i++)
                {
                    if (dragonList[i].Type == currDragonType && dragonList[i].Name == currDragonName)
                    {
                        dragonList[i].Damage = currDragonDamage;
                        dragonList[i].Health = currDragonHealth;
                        dragonList[i].Armor = currDragonArmor;
                        return;
                    }
                }
            }

            Dragon currDragon = new Dragon(currDragonType, currDragonName, currDragonDamage, currDragonHealth, currDragonArmor);
            dragonList.Add(currDragon);

        }

        static void AddDefaultVAluesIfThereIsANullInout(string[] dragonSpecifications)
        {
            string damage = dragonSpecifications[2];
            string health = dragonSpecifications[3];
            string armor = dragonSpecifications[4];

            if (damage == "null")
            {
                damage = "45";
            }

            if (health == "null")
            {
                health = "250";
            }

            if (armor == "null")
            {
                armor = "10";
            }

            dragonSpecifications[2] = damage;
            dragonSpecifications[3] = health;
            dragonSpecifications[4] = armor;
        }

        static void DisplayAllDragons(List<Dragon> dragonList)
        {
            Dictionary<string, SortedDictionary<string, int[]>> orderByType = new Dictionary<string, SortedDictionary<string, int[]>>();

            foreach (var dragon in dragonList)
            {
                string dragonType = dragon.Type;
                string dragonName = dragon.Name;
                int dragoneDamage = dragon.Damage;
                int dragonHealth = dragon.Health;
                int dragonArmor = dragon.Armor;
                int[] dragonStats = new int[3] { dragoneDamage, dragonHealth, dragonArmor };

                SortedDictionary<string, int[]> currDragonStats = new SortedDictionary<string, int[]>()
                {
                    {dragonName, dragonStats }
                };

                if (orderByType.ContainsKey(dragonType))
                {
                    orderByType[dragonType].Add(dragonName, dragonStats);
                }

                else
                {
                    orderByType.Add(dragonType, currDragonStats);
                }
            }

            

            foreach (var dragonType in orderByType)
            {
                decimal averageDamage = 0;
                decimal averageHealth = 0;
                decimal averageArmor = 0;

                foreach (var dragon in dragonType.Value)
                {
                    averageDamage += dragon.Value[0];
                    averageHealth += dragon.Value[1];
                    averageArmor += dragon.Value[2];
                }
                averageDamage /= dragonType.Value.Count;
                averageHealth /= dragonType.Value.Count;
                averageArmor /= dragonType.Value.Count;

                Console.WriteLine($"{dragonType.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                foreach (var dragon in dragonType.Value)
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }
    }
}

