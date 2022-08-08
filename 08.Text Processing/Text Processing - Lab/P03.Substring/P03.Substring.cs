using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string removingElement = Console.ReadLine();
            string word = Console.ReadLine();
            string result = string.Empty;

            while (word.Contains(removingElement))
            {
                word = word.Replace(removingElement, "");
            }

            Console.WriteLine(word);
        }
    }
}