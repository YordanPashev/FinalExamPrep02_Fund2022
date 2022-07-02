using System;
using System.Text;

namespace P02.FromLeftToTheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());


            for (int i = 1; i <= lines; i++)
            {
                long leftNumSum = 0;
                long rightNumSum = 0;
                string input = Console.ReadLine();
                StringBuilder right = new StringBuilder();
                StringBuilder left = new StringBuilder();
                for (int j = 0; j <= input.Length; j++)
                {
                    if (input[j] != ' ')
                    {
                        left.Append(input[j]);
                    }
                    else
                    {
                        for (int k = j + 1; k < input.Length; k++)
                        {
                            right.Append(input[k]);
                        }
                        break;
                    }
                }
                string right1 = right.ToString();
                string left1 = left.ToString();
                long rightNum = long.Parse(right1);
                long leftNum = long.Parse(left1);
                if (leftNum > rightNum)
                {
                    for (int l = 0; l < left1.Length; l++)
                    {
                        leftNumSum += leftNum % 10;
                        leftNum /= 10;
                    }
                    Console.WriteLine(Math.Abs(leftNumSum));
                }
                else
                {
                    for (int l = 0; l < right.Length; l++)
                    {
                        rightNumSum += rightNum % 10;
                        rightNum /= 10;
                    }
                    Console.WriteLine(Math.Abs(rightNumSum));
                }
            }


        }
    }
}