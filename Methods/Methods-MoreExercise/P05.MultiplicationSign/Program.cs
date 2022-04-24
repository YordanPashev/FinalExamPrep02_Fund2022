using System;
using System.Linq;

namespace P05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int[] arrOfTheThreeNumbers = new int[3] { firstNumber, secondNumber, thirdNumber };

            if (arrOfTheThreeNumbers.Contains(0))
            {
                Console.WriteLine("zero");
            }
            else
            {
                string result = CheckResultNegativeOrPositive(arrOfTheThreeNumbers);
                Console.WriteLine(result);
            }
        }

        static string CheckResultNegativeOrPositive(int[] arrOfTheThreeNumbers)
        {
            int negativeNumbersCounter = 0;
            string result = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                if (arrOfTheThreeNumbers[i] < 0)
                {
                    negativeNumbersCounter++;
                }
            }

            if (negativeNumbersCounter == 0 || negativeNumbersCounter == 2)
            {
                result = "positive";
            }
            else if (negativeNumbersCounter == 1 || negativeNumbersCounter == 3)
            {
                result = "negative";
            }

            return result;
        }
    }
}