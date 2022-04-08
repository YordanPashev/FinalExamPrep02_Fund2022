using System;

namespace P03.Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double capacityOfPeople = double.Parse(Console.ReadLine());
            double numberOfPeople = double.Parse(Console.ReadLine());

            double courses = Math.Ceiling(capacityOfPeople / numberOfPeople);
            Console.WriteLine(courses);
        }
    }
}
