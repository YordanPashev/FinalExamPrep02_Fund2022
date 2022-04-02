using System;
using System.Text.RegularExpressions;

namespace P02.AddAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int totalCalories = 0;
            Regex regex = new Regex(@"([#|\|])(?<item>[A-Za-z\s]+)(\1)(?<date>[0-9]{2}\/[0-9]{2}\/[0-9]{2})(\1)(?<kcal>[0-9]+)(\1)");
            MatchCollection matches = regex.Matches(input);
            foreach (Match item in matches)
            {
                totalCalories += int.Parse(item.Groups["kcal"].Value);
            }

            int days = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups["item"].Value}, Best before: {item.Groups["date"].Value}, Nutrition: {item.Groups["kcal"].Value}");
            }
        }
    }
}
