using System;

namespace P01.DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = new string[7] {
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            };
            int input = int.Parse(Console.ReadLine());
            if (input > 0 && input <= 7)
            {
                Console.WriteLine(daysOfWeek[input - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}