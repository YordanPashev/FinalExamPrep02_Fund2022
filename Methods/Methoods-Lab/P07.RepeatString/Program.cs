using System;
using System.Text;

namespace P07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                string input = Console.ReadLine();
                int repeatTimes = int.Parse(Console.ReadLine());
                Console.WriteLine(GetStringResult(input, repeatTimes));
            }
            static string GetStringResult(string input, int rep)
            {
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < rep; i++)
                {
                    result.Append(input);
                }
                return result.ToString();
            }

        }
    }
}
