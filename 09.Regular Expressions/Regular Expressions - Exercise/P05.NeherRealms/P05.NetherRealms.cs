using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P05.NetherRealms
{
    class Demon
    {
        public Demon(string name, int health, decimal damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }
        public string Name { get; set; }
        public int Health { get; set; }
        public decimal Damage { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Demon> listOfDemons = new List<Demon>();

            string[] demonsNamesList = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            string onlyLettersPattern = @"[^0-9+-/*\.]";
            string onlyNumbersPatter = @"[-]?([0-9]+)(\.[0-9]+)?";
            string multiplyAndDividePattern = @"[/*]";

            foreach (string demonsName in demonsNamesList)
            {
                if (demonsName.Contains(' '))
                {
                    continue;
                }
                int currDemonHealth = CalculateDemonsHealth(demonsName, onlyLettersPattern);
                decimal currDemonsDamage = CalculateDemonsDamage(demonsName, onlyNumbersPatter, multiplyAndDividePattern);
                Demon currDemonInfo = new Demon(demonsName, currDemonHealth, currDemonsDamage);
                listOfDemons.Add(currDemonInfo);
            }

            DisplayAllDemonsSpecifications(listOfDemons);
        }

        static int CalculateDemonsHealth(string demonsName, string onlyLettersPattern)
        {
            MatchCollection lettersOnly = Regex.Matches(demonsName, onlyLettersPattern);

            int totalDemonHealth = 0;
            foreach (Match letter in lettersOnly)
            {
                char currChar = char.Parse(letter.Value);
                totalDemonHealth += currChar;
            }

            return totalDemonHealth;
        }

        static decimal CalculateDemonsDamage(string demonsName, string onlyNumbersPatter, string multiplyAndDividePattern)
        {
            MatchCollection numbersOnly = Regex.Matches(demonsName, onlyNumbersPatter);

            decimal totalDemonDamage = 0;
            foreach (Match digit in numbersOnly)
            {
                decimal currDigit = decimal.Parse(digit.Value);
                totalDemonDamage += currDigit;
            }


            Regex multiAndDividePattern = new Regex(multiplyAndDividePattern);

            if (multiAndDividePattern.IsMatch(demonsName))
            {
                MatchCollection multiAndDivideSings = multiAndDividePattern.Matches(demonsName);
                totalDemonDamage = DivideAndMultiplTotalDemonDamage(multiAndDivideSings, totalDemonDamage);
            }


            return totalDemonDamage;
        }

        static decimal DivideAndMultiplTotalDemonDamage(MatchCollection multiAndDivideSings, decimal totalDemonDamage)
        {
            foreach (Match sign in multiAndDivideSings)
            {
                if (sign.Value == "/")
                {
                    totalDemonDamage /= 2;
                }

                else if (sign.Value == "*")
                {
                    totalDemonDamage *= 2;
                }
            }

            return totalDemonDamage;
        }

        static void DisplayAllDemonsSpecifications(List<Demon> listOfDemons)
        {
            foreach (var demon in listOfDemons.OrderBy(n => n.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }
    }  
}
