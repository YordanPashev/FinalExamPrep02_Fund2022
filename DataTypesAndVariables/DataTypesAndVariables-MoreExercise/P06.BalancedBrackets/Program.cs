using System;

namespace P06.BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int openBracketsCounter = 0;
            bool openBracket = false;
            bool closeBracket = false;
            bool isBalanced = false;
            string[] arr = new string[lines];

            for (int i = 0; i < lines; i++)
            {
                arr[i] = Console.ReadLine();

                if (arr[i] == "(")
                {
                    openBracket = true;
                    openBracketsCounter++;
                    if (openBracketsCounter >= 2)
                    {
                        isBalanced = false;
                        continue;
                    }
                }
                else
                {
                    if (arr[i] == ")")
                    {
                        closeBracket = true;
                        if (openBracket == false)
                        {
                            isBalanced = false;
                            openBracketsCounter = 2;
                            continue;
                        }
                        else if (openBracketsCounter < 2)
                        {
                            closeBracket = false;
                            openBracket = false;
                            openBracketsCounter = 0;
                            continue;
                        }
                    }
                }
            }
            if (closeBracket == false &&
            openBracket == false)
            {
                isBalanced = true;
            }

            if (isBalanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
