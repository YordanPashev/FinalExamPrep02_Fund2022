using System;

namespace P01DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                string inputType = Console.ReadLine();
                string input = Console.ReadLine();

                if (inputType == "int")
                {
                    int result = MyltiplyByTwo(int.Parse(input));
                    Console.WriteLine(result);
                }

                else if (inputType == "real")
                {
                    double result = MyltiplyByOneAndAHalf(double.Parse(input));
                    Console.WriteLine($"{result:F2}");
                }

                else if (inputType == "string")
                {
                    PrintString(input);
                }
            }

            static int MyltiplyByTwo(int number)
            {
                int result = number * 2;
                return result;
            }

            static double MyltiplyByOneAndAHalf(double number)
            {
                double result = number * 1.5;
                return result;
            }

            static void PrintString(string input)
            {
                Console.WriteLine($"${input}$");
            }
        }
    }
}