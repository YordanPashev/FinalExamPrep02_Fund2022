using System;

namespace ASCIISumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string randomString = Console.ReadLine();
            int result = 0;

            int[] charRangeValues = FindStartAndEndCharValues(firstChar, secondChar);

            foreach (char currChar in randomString)
            {
                int startCharValue = charRangeValues[0];
                int endCharValue = charRangeValues[1];
                int currCharValue = currChar;

                if (currCharValue > startCharValue && currCharValue < endCharValue)
                {
                    result += currCharValue;
                }
            }

            Console.WriteLine(result);
        }

        static int[] FindStartAndEndCharValues(int firstChar, int secondChar)
        {
            int firstCharValue = firstChar;
            int secondCharValue = secondChar;

            if (firstChar > secondChar)
            {
                return new int[] { secondChar, firstChar };
            }

            else
            {
                return new int[] { firstChar, secondChar };
            }
        }
    }
}