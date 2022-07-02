using System;

namespace P02.CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintClosestPointToOrigin(x1, y1, x2, y2);
        }

        static void PrintClosestPointToOrigin(double x1, double y1, double x2, double y2)
        {
            double result1 = Math.Pow(x1, y1);
            double result2 = Math.Pow(x2, y2);

            if (result1 < result2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
