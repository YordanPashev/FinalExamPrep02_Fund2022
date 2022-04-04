using System;

namespace P07.TheatrePromotion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine()), price = 0;

            switch (day)
            {
                case "Weekday":
                    if (0 <= age && age <= 18)
                    {
                        Console.WriteLine($"{price + 12}$");
                        break;
                    }
                    else if (18 < age && age <= 64)
                    {
                        Console.WriteLine($"{price + 18}$");
                        break;

                    }
                    else if (64 < age && age <= 122)
                    {
                        Console.WriteLine($"{price + 12}$");
                        break;
                    }
                    Console.WriteLine("Error!");
                    break;

                case "Weekend":
                    if (0 <= age && age <= 18)
                    {
                        Console.WriteLine($"{price + 15}$");
                        break;
                    }
                    else if (18 < age && age <= 64)
                    {
                        Console.WriteLine($"{price + 20}$");
                        break;

                    }
                    else if (64 < age && age <= 122)
                    {
                        Console.WriteLine($"{price + 15}$");
                        break;
                    }
                    Console.WriteLine("Error!");
                    break;


                case "Holiday":
                    if (0 <= age && age <= 18)
                    {
                        Console.WriteLine($"{price + 5}$");
                        break;
                    }
                    else if (18 < age && age <= 64)
                    {
                        Console.WriteLine($"{price + 12}$");
                        break;

                    }
                    else if (64 < age && age <= 122)
                    {
                        Console.WriteLine($"{price + 10}$");
                        break;
                    }
                    Console.WriteLine("Error!");
                    break;
            }
        }
    }
}
