using System;
using System.Collections.Generic;

namespace P02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOFWagons = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToList();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = cmdArgs[0];

                if (action == "Delete")
                {
                    int elementToDelete = int.Parse(cmdArgs[1]);
                    listOFWagons.RemoveAll(element => elementToDelete == element);
                }

                else if (action == "Insert")
                {
                    int elementToAdd = int.Parse(cmdArgs[1]);
                    int index = int.Parse(cmdArgs[2]);

                    listOFWagons.Insert(index, elementToAdd);
                }
            }

            Console.WriteLine(string.Join(" ", listOFWagons));
        }
    }
}
