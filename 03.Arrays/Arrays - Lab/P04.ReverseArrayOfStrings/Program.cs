using System;
using System.Linq;

namespace P04.ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] symbols = Console.ReadLine().Split(' ').ToArray();
            Array.Reverse(symbols);
            for (int i = 0; i < symbols.Length; i++)
            {
                Console.Write(symbols[i] + " ");
            }
        }
    }
}