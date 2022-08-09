using System;
using System.Linq;
using System.Collections.Generic;

namespace P03.HeroesOfCodeAndLogicVII
{
    class Hero
    {
        public Hero(string name, int hp, int mana)
        {
            this.Name = name;
            this.HP = hp;
            this.Mana = mana;
        }
        public string Name { get; set; }
        public int HP { get; set; }
        public int Mana { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Hero> listOfheroes = new List<Hero>();
            int numberOfHeroes = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfHeroes; i++)
            {
                AddHeroToTheList(listOfheroes);
            }

            string cmd = string.Empty;

            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = cmdArgs[0];

                if (action == "CastSpell")
                {
                    TryToCastSpell(cmdArgs, listOfheroes);
                }

                else if (action == "TakeDamage")
                {
                    TakeDamage(cmdArgs, listOfheroes);
                }

                else if (action == "Recharge")
                {
                    Recharge(cmdArgs, listOfheroes);
                }

                else if (action == "Heal")
                {
                    Heal(cmdArgs, listOfheroes);
                }
            }

            DisplayAllHeroesLeft(listOfheroes);
        }

        static void AddHeroToTheList(List<Hero> listOfheroes)
        {
            string[] currHeroInfo = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

            string name = currHeroInfo[0];
            int hp = int.Parse(currHeroInfo[1]);
            int mana = int.Parse(currHeroInfo[2]);

            if (hp > 100)
            {
                hp = 100;
            }

            if (mana > 200)
            {
                mana = 200;
            }

            Hero heroDataToAdd = new Hero(name, hp, mana);
            listOfheroes.Add(heroDataToAdd);
        }

        static void TryToCastSpell(string[] cmdArgs, List<Hero> listOfheroes)
        {
            string heroName = cmdArgs[1];
            int manaNeeded = int.Parse(cmdArgs[2]);
            string spellName = cmdArgs[3];

            var currHero = listOfheroes.Find(h => h.Name == heroName);

            if (currHero.Mana >= manaNeeded)
            {
                currHero.Mana -= manaNeeded;
                Console.WriteLine($"{currHero.Name} has successfully cast {spellName} and now has { currHero.Mana} MP!");
            }

            else
            {
                Console.WriteLine($"{currHero.Name} does not have enough MP to cast {spellName}!");
            }
        }

        static void TakeDamage(string[] cmdArgs, List<Hero> listOfheroes)
        {
            string heroName = cmdArgs[1];
            int damage = int.Parse(cmdArgs[2]);
            string attacker = cmdArgs[3];

            var currHero = listOfheroes.Find(h => h.Name == heroName);

            currHero.HP -= damage;
            if (currHero.HP > 0)
            {
                Console.WriteLine($"{currHero.Name} was hit for {damage} HP by {attacker} and now has {currHero.HP} HP left!");
            }

            else
            {
                Console.WriteLine($"{currHero.Name} has been killed by {attacker}!");
                listOfheroes.Remove(currHero);
            }
        }

        static void Recharge(string[] cmdArgs, List<Hero> listOfheroes)
        {
            string heroName = cmdArgs[1];
            int amount = int.Parse(cmdArgs[2]);

            var currHero = listOfheroes.Find(h => h.Name == heroName);


            if (currHero.Mana + amount > 200)
            {

                amount = 200 - currHero.Mana;
                currHero.Mana = 200;
            }

            else
            {
                currHero.Mana += amount;
            }

            Console.WriteLine($"{currHero.Name} recharged for {amount} MP!");
        }

        static void Heal(string[] cmdArgs, List<Hero> listOfheroes)
        {
            string heroName = cmdArgs[1];
            int amount = int.Parse(cmdArgs[2]);

            var currHero = listOfheroes.Find(h => h.Name == heroName);


            if (currHero.HP + amount > 100)
            {

                amount = 100 - currHero.HP;
                currHero.HP = 100;
            }

            else
            {
                currHero.HP += amount;
            }

            Console.WriteLine($"{currHero.Name} healed for {amount} HP!");
        }


        static void DisplayAllHeroesLeft(List<Hero> listOfheroes)
        {
            foreach (var hero in listOfheroes)
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine($"  HP: {hero.HP}");
                Console.WriteLine($"  MP: {hero.Mana}");
            }
        }
    }
}


