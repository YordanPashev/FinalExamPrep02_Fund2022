using System;

namespace P01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMin(firstNum, secondNum, thirdNum));
        }
        static double GetMin(int firstNum, int secondNum, int thirdNum)
        {
            if (firstNum > secondNum && secondNum < thirdNum)
            {
                return secondNum;
            }

            else if (thirdNum > firstNum && firstNum < secondNum)
            {
                return firstNum;
            }
            else
            {
                return thirdNum;
            }
        }
    }
}
