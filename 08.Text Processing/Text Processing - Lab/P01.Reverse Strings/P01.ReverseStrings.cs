using System;
using System.Linq;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] Args)
        {
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string word = input;
                Console.WriteLine($"{word} = {string.Join("", word.Reverse())}");
            }
            
        }
    }
}