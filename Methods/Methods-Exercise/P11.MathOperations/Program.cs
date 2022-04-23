using System;

namespace P11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            Console.WriteLine(Calculate(firstNum, secondNum, @operator));
        }
        static double Calculate(double firstNum, double secondNum, char @operator)
        {
            double result = 0;
            switch (@operator)
            {
                case '+':
                    result = firstNum + secondNum;
                    break;
                case '-':
                    result = firstNum - secondNum;
                    break;
                case '*':
                    result = firstNum * secondNum;
                    break;
                case '/':
                    result = firstNum / secondNum;
                    break;
            }
            return result;
        }
    }
}
