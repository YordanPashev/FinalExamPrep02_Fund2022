using System;

namespace P07.NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            PrintMatrix(input);
        }

        static void PrintMatrix(int input)
        {
            int printNumber = input;
            for (int row = 1; row <= input; row++)
            {
                for (int col = 1; col <= input; col++)
                {
                    if (col != input)
                    {
                        Console.Write(printNumber + " ");
                        continue;
                    }
                    Console.Write(printNumber);
                }
                Console.WriteLine();
            }
        }
    }
}
