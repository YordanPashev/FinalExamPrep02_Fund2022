using System;
using System.Collections.Generic;

namespace P04.TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] arrOfLastThreenumbers = new int[3];
            int nextSum = 1;
            List<int> result = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                result.Add(nextSum);
                arrOfLastThreenumbers[0] = arrOfLastThreenumbers[1];
                arrOfLastThreenumbers[1] = arrOfLastThreenumbers[2];
                arrOfLastThreenumbers[2] = nextSum;
                nextSum = arrOfLastThreenumbers[0] + arrOfLastThreenumbers[1] + arrOfLastThreenumbers[2];

            }

            Console.Write(string.Join(" ", result));
        }
    }
}
