using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            SortedDictionary<int, int> result = new SortedDictionary<int, int>();
            int counter = 1;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (!result.ContainsKey(numbers[i]))
                {
                    result.Add(numbers[i], counter);
                }
                else
                {
                    result[numbers[i]]++;
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
