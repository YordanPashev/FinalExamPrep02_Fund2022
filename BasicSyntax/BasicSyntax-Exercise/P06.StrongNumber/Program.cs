using System;

namespace P06.StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var digit = Console.ReadLine();
            var num = int.Parse(digit);
            var num2 = num;
            int[] arr = new int[digit.Length];
            int n = 0, totalSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                var n2 = num % 10;
                num /= 10;
                if (n2 == 0)
                {
                    n2 = 1;
                }
                arr[n] = n2;

                for (int j = 1; j < n2; j++)
                {
                    arr[n] *= j;
                }
                n++;
            }
            for (int k = 0; k < arr.Length; k++)
            {
                totalSum += arr[k];
            }
            if (totalSum == num2)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}