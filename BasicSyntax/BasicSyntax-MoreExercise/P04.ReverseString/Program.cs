using System;
using System.Text;

namespace P04.ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                string input = Console.ReadLine();
                StringBuilder output = new StringBuilder();
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    output.Append(input[i]);
                }
                Console.WriteLine(output);
            }
        }
    }
}
