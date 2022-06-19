using System;
using System.Collections.Generic;

namespace P03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int visits = int.Parse(Console.ReadLine());
            List<string> visitors = new List<string>();

            for (int i = 1; i <= visits; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = cmdArgs[0];
                string action = cmdArgs[2];

                if (action == "going!")
                {

                    if (visitors.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }

                    else
                    {
                        visitors.Add(name);
                    }
                }

                else if (action == "not")
                {

                    if (visitors.Contains(name))
                    {
                        visitors.Remove(name);
                    }

                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            Console.WriteLine(string.Join("\n", visitors));
        }
    }
}
