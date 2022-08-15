using System;
using System.Text.RegularExpressions;

namespace P01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @(b([A-Z][a-z]{1,})( )([A-Z][a-z]{1,})b);

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            Console.WriteLine(string.Join( , matches));

        }
    }
}
