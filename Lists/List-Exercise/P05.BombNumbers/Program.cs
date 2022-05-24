using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bombSpecifics = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int specialNumber = bombSpecifics[0];
            int bombPower = bombSpecifics[1];

            for (int currentElementIndex = 0; currentElementIndex < listOfNumbers.Count; currentElementIndex++)
            {
                if (listOfNumbers[currentElementIndex] == specialNumber)
                {
                    for (int rightSideElementsToRemove = 1; rightSideElementsToRemove <= bombPower; rightSideElementsToRemove++)
                    {

                        if (currentElementIndex + 1 > listOfNumbers.Count - 1)
                        {
                            break;
                        }

                        else
                        {
                            int idexToRemoveOnTheRightSide = currentElementIndex + 1;
                            listOfNumbers.RemoveAt(idexToRemoveOnTheRightSide);
                        }
                    }

                    for (int lefttSideElementsToRemove = 1; lefttSideElementsToRemove <= bombPower; lefttSideElementsToRemove++, currentElementIndex--)
                    {
                        int idexToRemoveOnTheLeftSide = currentElementIndex - 1;
                        if (idexToRemoveOnTheLeftSide < 0)
                        {
                            break;
                        }

                        else
                        {
                            listOfNumbers.RemoveAt(idexToRemoveOnTheLeftSide);
                        }
                    }

                    listOfNumbers.Remove(specialNumber);
                    currentElementIndex = -1;
                    currentElementIndex = 0;
                }
            }

            int totalSumOFAllElements = listOfNumbers.Sum();
            Console.WriteLine(totalSumOFAllElements);

        }
    }
}