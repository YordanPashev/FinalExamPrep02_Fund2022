using System;

namespace P03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            switch (comand)
            {
                case "add":
                    Add(firstNum, secondNum);
                    break;

                case "multiply":
                    Multiply(firstNum, secondNum);
                    break;

                case "subtract":
                    Subtract(firstNum, secondNum);
                    break;

                case "divide":
                    Divide(firstNum, secondNum);
                    break;
            }
        }
        static void Add(int firstNum, int secondNum)
        {

            Console.WriteLine(firstNum + secondNum);
        }

        static void Multiply(int firstNum, int secondNum)
        {

            Console.WriteLine(firstNum * secondNum);
        }

        static void Subtract(int firstNum, int secondNum)
        {

            Console.WriteLine(firstNum - secondNum);
        }

        static void Divide(int firstNum, int secondNum)
        {

            Console.WriteLine(firstNum / secondNum);
        }
    }
}
