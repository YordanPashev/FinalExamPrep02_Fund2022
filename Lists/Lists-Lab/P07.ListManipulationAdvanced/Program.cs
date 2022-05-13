using System;
using System.Linq;
using System.Collections.Generic;

namespace P07.ListManipulationAdvanced
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
            string currentListOfNumbers = string.Join(" ", listOfNumbers);
            string originListOfNumbers = string.Join(" ", listOfNumbers);
            List<int> modifiedListOfNumbers = currentListOfNumbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while ((cmd = Console.ReadLine()) != "end")
            {
                currentListOfNumbers = string.Join(" ", modifiedListOfNumbers);
                string[] cmdArgs = cmd
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();

                if (cmdArgs[0] == "Add")
                {
                    int number = int.Parse(cmdArgs[1]);
                    modifiedListOfNumbers = AddNumber(number, modifiedListOfNumbers);
                }

                else if (cmdArgs[0] == "Remove")
                {
                    int number = int.Parse(cmdArgs[1]);
                    modifiedListOfNumbers = RemoveNumber(number, modifiedListOfNumbers);
                }

                else if (cmdArgs[0] == "RemoveAt")
                {
                    int index = int.Parse(cmdArgs[1]);
                    modifiedListOfNumbers = RemoveIndex(index, modifiedListOfNumbers);
                }

                else if (cmdArgs[0] == "Insert")
                {
                    int number = int.Parse(cmdArgs[1]);
                    int index = int.Parse(cmdArgs[2]);
                    modifiedListOfNumbers = InsertIndex(index, number, modifiedListOfNumbers);
                }

                else if (cmdArgs[0] == "Contains")
                {
                    int number = int.Parse(cmdArgs[1]);
                    bool result = CheckIsCointainingANumber(number, modifiedListOfNumbers);

                    if (result)
                    {
                        Console.WriteLine("Yes");
                    }

                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }

                else if (cmdArgs[0] == "PrintEven")
                {
                    PrintAllEvenNumbers(currentListOfNumbers);

                }

                else if (cmdArgs[0] == "PrintOdd")
                {
                    PrintAllOddNumbers(currentListOfNumbers);
                }

                else if (cmdArgs[0] == "GetSum")
                {
                    PrintSumOFAllNumbers(modifiedListOfNumbers);
                }

                else if (cmdArgs[0] == "Filter")
                {
                    string condition = cmdArgs[1];
                    int number = int.Parse(cmdArgs[2]);
                    PrintFilteredNums(condition, number, currentListOfNumbers);
                }
            }

            List<int> origin = originListOfNumbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            bool isChanged = true;

            if (modifiedListOfNumbers.Count != origin.Count)
            {
                PrintList(modifiedListOfNumbers);
            }

            else
            {
                int shortenList = Math.Min(modifiedListOfNumbers.Count, origin.Count);

                for (int i = 0; i < shortenList; i++)
                {
                    if (origin[i] == modifiedListOfNumbers[i])
                    {
                        isChanged = false;
                        continue;
                    }
                    isChanged = true;
                    break;
                }
                if (isChanged)
                {
                    PrintList(modifiedListOfNumbers);
                }
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

            static bool CheckIsCointainingANumber(int number, List<int> list)
            {
                bool isContainingTheNumber = list.Contains(number);
                return isContainingTheNumber;
            }

            static void PrintAllEvenNumbers(string listOfNumbers)
            {
                List<int> listWithAllEvenNumbers = listOfNumbers.Split(" ").Select(int.Parse).ToList();
                listWithAllEvenNumbers.RemoveAll(number => number % 2 != 0);
                PrintList(listWithAllEvenNumbers);
            }

            static void PrintAllOddNumbers(string listOfNumbers)
            {
                List<int> listWithAllOddNumbers = listOfNumbers.Split(" ").Select(int.Parse).ToList();
                listWithAllOddNumbers.RemoveAll(number => number % 2 == 0);
                PrintList(listWithAllOddNumbers);
            }

            static void PrintSumOFAllNumbers(List<int> list)
            {
                int totalSum = 0;
                foreach (var item in list)
                {
                    totalSum += item;
                }

                Console.WriteLine(totalSum);
            }

            static void PrintFilteredNums(string condition, int filterNum, string listOfNumbers)
            {
                List<int> filteredList = listOfNumbers.Split(" ").Select(int.Parse).ToList();
                switch (condition)
                {
                    case ">":
                        filteredList.RemoveAll(number => number <= filterNum);
                        PrintList(filteredList);
                        break;

                    case ">=":
                        filteredList.RemoveAll(number => number < filterNum);
                        PrintList(filteredList);
                        break;

                    case "<":
                        filteredList.RemoveAll(number => number >= filterNum);
                        PrintList(filteredList);
                        break;

                    case "<=":
                        filteredList.RemoveAll(number => number > filterNum);
                        PrintList(filteredList);
                        break;
                }
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
}