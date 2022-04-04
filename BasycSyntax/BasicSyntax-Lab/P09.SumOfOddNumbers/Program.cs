using System;

namespace P09.SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0, i = 1;
            bool isFinish = false;

            while (isFinish == false)
            {
                if (n == 0)
                {
                    isFinish = true;
                    break;
                }
                sum += i;
                Console.WriteLine(i);
                i += 2;
                n--;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
