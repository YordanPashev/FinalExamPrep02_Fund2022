using System;
using System.Linq;
using System.Text;

namespace MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string multiplicand = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());
            int tens = 0;

            if (CheckIfMultiplicantIsZero(multiplicand) || multiplier == 0)
            {
                Console.WriteLine("0");
                return;
            }

            StringBuilder sumedUnits = new StringBuilder();
            int previousTens = 0;

            for (int i = multiplicand.Length - 1; i >= 0; i--)
            {
                int digit = Convert.ToInt32(multiplicand[i]) - 48;
                int resultFromMultipling = digit * multiplier;
                tens = resultFromMultipling / 10;
                int units = (resultFromMultipling % 10) + previousTens;

                if (units > 9)
                {
                    tens += units / 10;
                    units %= 10;
                }
                sumedUnits.Insert(0, units);
                previousTens = tens;
            }

            sumedUnits.Insert(0, tens);
            string finalResult = sumedUnits.ToString();
            finalResult = finalResult.TrimStart('0');
            Console.WriteLine(finalResult);
        }

        static bool CheckIfMultiplicantIsZero(string multiplicand)
        {
            foreach (char digit in multiplicand)
            {
                if (digit != '0')
                {
                    return false;
                }
            }

            return true;
        }
    }
}