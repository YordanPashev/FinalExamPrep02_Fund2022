using System;

namespace P01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int[] amountOfPeople = new int[wagons];
            int totalSum = 0;

            for (int i = 0; i < wagons; i++)
            {

                amountOfPeople[i] = int.Parse(Console.ReadLine());
                Console.Write(amountOfPeople[i] + " ");
                totalSum += amountOfPeople[i];
            }
            Console.WriteLine();
            Console.WriteLine(totalSum);
        }
    }
}
