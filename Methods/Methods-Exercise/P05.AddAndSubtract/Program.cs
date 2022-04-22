using System;

namespace P05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstDigit = int.Parse(Console.ReadLine());
            int secondDigit = int.Parse(Console.ReadLine());
            int thirdDigit = int.Parse(Console.ReadLine());
            int addResult = Add(firstDigit, secondDigit);
            int substractResult = Substract(addResult, thirdDigit);
            Console.WriteLine(substractResult);
        }

        static int Add(int firstDigit, int secondDigit)
        {
            return firstDigit + secondDigit;
        }

        static int Substract(int addSum, int thirdDigit)
        {
            return addSum - thirdDigit;
        }
    }
}
