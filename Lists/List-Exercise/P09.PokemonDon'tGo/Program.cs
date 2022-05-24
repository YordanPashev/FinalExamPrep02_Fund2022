using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.PokemonDon_tGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numberOfPokemons = Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToList();

            int totalSum = 0;

            while (numberOfPokemons.Count != 0)
            {
                int indexToRemove = int.Parse(Console.ReadLine());
                int digitToRemove = 0;
                int lastElementIndex = numberOfPokemons.Count - 1;
                int firstElementIndex = 0;

                if (indexToRemove < 0)
                {
                    digitToRemove = numberOfPokemons[0];
                    numberOfPokemons.RemoveAt(firstElementIndex);
                    numberOfPokemons.Insert(firstElementIndex, numberOfPokemons[lastElementIndex - 1]);
                    totalSum += digitToRemove;
                    ModifyPokemonValues(numberOfPokemons, digitToRemove);
                }

                else if (indexToRemove > numberOfPokemons.Count - 1)
                {
                    digitToRemove = numberOfPokemons[lastElementIndex];
                    numberOfPokemons.RemoveAt(lastElementIndex);
                    numberOfPokemons.Insert(lastElementIndex, numberOfPokemons[firstElementIndex]);
                    totalSum += digitToRemove;
                    ModifyPokemonValues(numberOfPokemons, digitToRemove);
                }

                else
                {
                    digitToRemove = numberOfPokemons[indexToRemove];
                    numberOfPokemons.RemoveAt(indexToRemove);
                    totalSum += digitToRemove;
                    ModifyPokemonValues(numberOfPokemons, digitToRemove);
                }
            }

            Console.WriteLine(totalSum);
        }

        static void ModifyPokemonValues(List<int> numberOfPokemons, int digitToRemove)
        {
            for (int i = 0; i < numberOfPokemons.Count; i++)
            {
                if (numberOfPokemons[i] <= digitToRemove)
                {
                    numberOfPokemons[i] += digitToRemove;
                }

                else if (numberOfPokemons[i] > digitToRemove)
                {
                    numberOfPokemons[i] -= digitToRemove;
                }
            }
        }
    }
}
