using System;
using System.Linq;

namespace P04.ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int rotationNumber = int.Parse(Console.ReadLine());

            int currentRotationNum = 0;
            for (int i = 0; i < rotationNumber; i++)
            {
                currentRotationNum = arr[0];

                for (int j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }

                arr[arr.Length - 1] = currentRotationNum;
            }

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
