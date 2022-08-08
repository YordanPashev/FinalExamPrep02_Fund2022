using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            char[] digits = inputLine.Where(ch => char.IsDigit(ch)).ToArray();
            char[] letters = inputLine.Where(ch => char.IsLetter(ch)).ToArray();
            char[] otherSymbols = inputLine.Where(ch => !char.IsLetterOrDigit(ch)).ToArray();

            Console.WriteLine(string.Join("", digits));
            Console.WriteLine(string.Join("", letters));
            Console.WriteLine(string.Join("", otherSymbols));
        }
    }
}