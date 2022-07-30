using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.CountCharsinaString
{
    class Program
    {
        static void Main(string[] Args)
        {
            string input = Console.ReadLine();
            string concatanatedInput = string.Concat(input.Where(ch => !char.IsWhiteSpace(ch)));
            Dictionary<char, int> result = new Dictionary<char, int>();

            foreach (char letter in concatanatedInput)
            {
                if (result.ContainsKey(letter))
                {
                    result[letter] += 1;
                }

                else
                {
                    result.Add(letter, 1);
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}