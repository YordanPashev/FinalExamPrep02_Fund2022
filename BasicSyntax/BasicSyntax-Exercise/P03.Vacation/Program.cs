using System;

namespace P03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var persons = double.Parse(Console.ReadLine());
            string type = Console.ReadLine(), day = Console.ReadLine();
            double totalPrice = 0;


            switch (type)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday":
                            totalPrice = 8.45 * persons;
                            break;
                        case "Saturday":
                            totalPrice = 9.8 * persons;
                            break;
                        case "Sunday":
                            totalPrice = 10.46 * persons;
                            break;
                    }

                    break;
                case "Business":
                    if (persons >= 100)
                    {
                        persons -= 10;
                    }
                    switch (day)
                    {
                        case "Friday":
                            totalPrice = 10.9 * persons;
                            break;
                        case "Saturday":
                            totalPrice = 15.6 * persons;
                            break;
                        case "Sunday":
                            totalPrice = 16 * persons;
                            break;
                    }
                    break;
                case "Regular":
                    switch (day)
                    {
                        case "Friday":
                            totalPrice = 15 * persons;
                            break;
                        case "Saturday":
                            totalPrice = 20 * persons;
                            break;
                        case "Sunday":
                            totalPrice = 22.50 * persons;
                            break;
                    }
                    break;
            }

            if (type == "Students" && persons >= 30)
            {
                totalPrice *= 0.85;
            }

            else if (type == "Regular" && persons >= 10 && persons <= 20)
            {
                totalPrice *= 0.95;
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
