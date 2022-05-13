using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNumbers = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToList();

            string cmd;

            while ((cmd = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = cmd
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();

                if (cmdArgs[0] == "Add")
                {
                    int number = int.Parse(cmdArgs[1]);
                    listOfNumbers = AddNumber(number, listOfNumbers);
                }

                else if (cmdArgs[0] == "Remove")
                {
                    int number = int.Parse(cmdArgs[1]);
                    listOfNumbers = RemoveNumber(number, listOfNumbers);
                }

                else if (cmdArgs[0] == "RemoveAt")
                {
                    int index = int.Parse(cmdArgs[1]);
                    listOfNumbers = RemoveIndex(index, listOfNumbers);
                }

                else if (cmdArgs[0] == "Insert")
                {
                    int number = int.Parse(cmdArgs[1]);
                    int index = int.Parse(cmdArgs[2]);
                    listOfNumbers = InsertIndex(index, number, listOfNumbers);
                }
            }

            PrintList(listOfNumbers);
        }
        static List<int> AddNumber(int number, List<int> list)
        {
            list.Add(number);
            return list;
        }

        static List<int> RemoveNumber(int number, List<int> list)
        {
            list.Remove(number);
            return list;
        }

        static List<int> RemoveIndex(int index, List<int> list)
        {
            list.RemoveAt(index);
            return list;
        }

        static List<int> InsertIndex(int index, int number, List<int> list)
        {
            list.Insert(index, number);
            return list;
        }

        static void PrintList(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                Console.Write(list[i] + " ");
            }

            Console.WriteLine(list[list.Count - 1]);
        }
    }
}