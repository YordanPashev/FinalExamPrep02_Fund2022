using System;

namespace P03.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            FindLongestLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        static void FindLongestLine(double x1, double y1, double x2, double y2,
                                    double x3, double y3, double x4, double y4)
        {
            double lineOneLenght = Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2);
            double lineTwolinght = Math.Pow(x3 - x4, 2) + Math.Pow(y3 - y4, 2);

            if (lineOneLenght >= lineTwolinght)
            {
                PrintClosestPointToOrigin(x1, y1, x2, y2);
            }

            else
            {
                PrintClosestPointToOrigin(x3, y3, x4, y4);
            }
        }

        static void PrintClosestPointToOrigin(double x, double y, double x1, double y1)
        {
            if ((x * x) + (y * y) <= (x1 * x1) + (y1 * y1))
            {
                Console.WriteLine($"({x}, {y})({x1}, {y1})");
            }

            else
            {
                Console.WriteLine($"({x1}, {y1})({x}, {y})");
            }
        }
    }
}
