using System;

namespace P04.PrintingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                int number = int.Parse(Console.ReadLine());
                LeftBody(number);
                RightBody(number);
            }

            static void LeftBody(int number)
            {
                for (int row = 1; row <= number; row++)
                {
                    for (int colum = 1; colum <= row; colum++)
                    {
                        if (colum != row)
                        {
                            Console.Write(colum + " ");
                        }
                        else
                        {
                            Console.Write(colum);
                        }

                    }
                    Console.WriteLine();
                }
            }

            static void RightBody(int number)
            {
                for (int row = number; row >= 1; row--)
                {
                    for (int colum = 1; colum < row; colum++)
                    {
                        if (colum != row)
                        {
                            Console.Write(colum + " ");
                        }
                        else
                        {
                            Console.Write(colum);
                        }
                    }
                    Console.WriteLine();
                }

            }
        }
    }
}
