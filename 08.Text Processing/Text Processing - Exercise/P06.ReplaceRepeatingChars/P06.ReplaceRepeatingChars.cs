using System;
using System.Text;

namespace ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string inputLine = Console.ReadLine();
            StringBuilder result = new StringBuilder(inputLine);

            for (int currChar = 0; currChar < result.Length - 1; currChar++)
            {
                int counter = 0;

                for (int nextChar = currChar + 1; nextChar < result.Length; nextChar++)
                {
                    if (result[currChar] == result[nextChar])
                    {
                        counter++;
                        continue;
                    }

                    break;

                }

                result.Remove(currChar + 1, counter);
            }

            Console.WriteLine(result);
        }
    }
}