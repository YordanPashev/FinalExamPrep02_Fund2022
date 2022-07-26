using System;

namespace P03.FloatingEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            bool isEqual = eps >= Math.Abs(n1 - n2);
            Console.WriteLine(isEqual);
        }
    }
}
