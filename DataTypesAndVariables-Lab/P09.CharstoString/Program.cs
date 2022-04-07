using System;
using System.Text;

namespace P09.CharstoString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char one = char.Parse(Console.ReadLine());
            char two = char.Parse(Console.ReadLine());
            char three = char.Parse(Console.ReadLine());

            StringBuilder word = new StringBuilder();
            word.Append($"{one}{two}{three}");
            Console.WriteLine(word);
        }
    }
}

