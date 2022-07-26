using System;

namespace P07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int courses = int.Parse(Console.ReadLine());
            int littersInTheTank = 0;
            for (int i = 1; i <= courses; i++)
            {
                int course = int.Parse(Console.ReadLine());
                if (littersInTheTank + course > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                else
                {
                    littersInTheTank += course;
                }
            }
            Console.WriteLine(littersInTheTank);
        }
    }
}
