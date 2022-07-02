using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Take_SkipRope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> listOfDigits = GetAllDigits(input);
            List<char> lettersAndSymbolsList = GetAllNonDigits(input);
            StringBuilder encryptedMessage = new StringBuilder();

            int[] takeCount = GetAllEvenIndexesDigits(listOfDigits);
            int[] skipCount = GetAllOddIndexesDigits(listOfDigits);

            for (int i = 0; i < takeCount.Length; i++)
            {
                encryptedMessage.Append(TakeCharsFromTheList(lettersAndSymbolsList, takeCount[i]));
                DeleteAllUnnecesseryCharsInCurrentIteration(lettersAndSymbolsList, takeCount[i], skipCount[i]);
            }

            Console.WriteLine(encryptedMessage);
        }


        static List<int> GetAllDigits(string input)
        {
            List<int> digits = new List<int>();
            foreach (char ch in input)
            {
                if (Char.IsDigit(ch))
                {
                    digits.Add((int)char.GetNumericValue(ch));
                }
            }

            return digits;
        }

        static List<char> GetAllNonDigits(string input)
        {
            List<char> nonDigits = new List<char>();
            foreach (char ch in input)
            {
                if (!Char.IsDigit(ch))

                    nonDigits.Add(ch);
            }

            return nonDigits;
        }

        static int[] GetAllEvenIndexesDigits(List<int> listOfDigits)
        {
            int[] allEvenPositionFromList = new int[listOfDigits.Count / 2];
            int evenNumArrayIndex = 0;
            for (int listIndex = 0; listIndex < listOfDigits.Count; listIndex++)
            {
                if (listIndex % 2 == 0)
                {
                    allEvenPositionFromList[evenNumArrayIndex] = listOfDigits[listIndex];
                    evenNumArrayIndex++;
                }
            }

            return allEvenPositionFromList;
        }

        static int[] GetAllOddIndexesDigits(List<int> listOfDigits)
        {
            int[] allOddPositionFromList = new int[listOfDigits.Count / 2];
            int oddNumArrayIndex = 0;

            for (int listIndex = 0; listIndex < listOfDigits.Count; listIndex++)
            {
                if (listIndex % 2 != 0)
                {
                    allOddPositionFromList[oddNumArrayIndex] = listOfDigits[listIndex];
                    oddNumArrayIndex++;
                }
            }

            return allOddPositionFromList;
        }

        static string TakeCharsFromTheList(List<char> lettersAndSymbolsList, int count)
        {
            StringBuilder currentIterationString = new StringBuilder();
            string currentResult = string.Empty;

            for (int i = 0; i < count; i++)
            {
                if (i > lettersAndSymbolsList.Count - 1)
                {
                    return currentResult;
                }
                currentIterationString.Append(lettersAndSymbolsList[i]);
                currentResult = currentIterationString.ToString();
            }


            return currentResult;
        }

        static void DeleteAllUnnecesseryCharsInCurrentIteration
            (List<char> lettersAndSymbolsList, int takeCount, int skipCount)
        {
            int numberCountToremove = takeCount + skipCount;
            if (numberCountToremove > lettersAndSymbolsList.Count)
            {
                lettersAndSymbolsList.RemoveRange(0, lettersAndSymbolsList.Count);
            }

            else
            {
                lettersAndSymbolsList.RemoveRange(0, takeCount + skipCount);
            }
        }
    }
}
