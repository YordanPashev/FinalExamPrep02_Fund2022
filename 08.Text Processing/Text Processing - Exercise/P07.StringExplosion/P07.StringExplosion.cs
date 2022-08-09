using System;
using System.Linq;
using System.Text;

namespace StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            int bombPower = 0;

            for (int currChar = 0; currChar < inputString.Length; currChar++)
            {
                if (inputString[currChar] != '>')
                {
                    if (bombPower == 0)
                    {
                        result.Append(inputString[currChar]);
                    }

                    else
                    {
                        bombPower--;
                    }
                }

                else
                {
                    result.Append(inputString[currChar]);
                    bombPower += (int)char.GetNumericValue(inputString[currChar + 1]);
                }
            }

            Console.WriteLine(result.ToString().TrimEnd());
        }
    }
}