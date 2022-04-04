using System;

namespace P05.MonthPrinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] months = new string[12];
            months[0] = "January";
            months[1] = "February";
            months[2] = "March";
            months[3] = "April";
            months[4] = "May";
            months[5] = "June";
            months[6] = "July";
            months[7] = "August";
            months[8] = "September";
            months[9] = "October";
            months[10] = "November";
            months[11] = "December";

            if (number > 12 || number <= 0)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine(months[number - 1]);
            }
        }
    }
}