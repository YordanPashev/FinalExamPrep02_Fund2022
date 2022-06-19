using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNUmbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];

                if (action == "Add")
                {
                    int number = int.Parse(cmdArgs[1]);
                    listOfNUmbers.Add(number);
                }

                else if (action == "Insert")
                {
                    int index = int.Parse(cmdArgs[2]);

                    if (index < 0 || index > listOfNUmbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    int number = int.Parse(cmdArgs[1]);
                    listOfNUmbers.Insert(index, number);
                }

                else if (action == "Remove")
                {
                    int index = int.Parse(cmdArgs[1]);

                    if (index < 0 || index > listOfNUmbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    listOfNUmbers.RemoveAt(index);
                }

                else if (action == "Shift")
                {
                    string direction = cmdArgs[1];
                    int count = int.Parse(cmdArgs[2]);
                    int realPerformanceCount = count % listOfNUmbers.Count;
                    if (direction == "left")
                    {
                        for (int countNumber = 1; countNumber <= realPerformanceCount; countNumber++)
                        {
                            listOfNUmbers.Add(listOfNUmbers[0]);
                            listOfNUmbers.RemoveAt(0);
                        }
                    }

                    else if (direction == "right")
                    {
                        for (int countNumber = 1; countNumber <= realPerformanceCount; countNumber++)
                        {
                            listOfNUmbers.Insert(0, listOfNUmbers[listOfNUmbers.Count - 1]);
                            listOfNUmbers.RemoveAt(listOfNUmbers.Count - 1);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", listOfNUmbers));
        }
    }
}

