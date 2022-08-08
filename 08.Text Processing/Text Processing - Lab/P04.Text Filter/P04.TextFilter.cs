using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Text Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string text = Console.ReadLine();
            string censoredText = string.Empty;


            for (int i = 0; i < banList.Length; i++)
            {
                string wordToBan = banList[i];

                censoredText = text.Replace(wordToBan, new string('*', wordToBan.Length));
                text = censoredText;
            }

            Console.WriteLine(censoredText);
        }
    }
}