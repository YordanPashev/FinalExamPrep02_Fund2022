using System;

namespace P06.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int result = CalculateRectangleArea(width, height);
            Console.WriteLine(result);
        }

        static int CalculateRectangleArea(int width, int height)
        {
            return width * height;
        }
    }
}
