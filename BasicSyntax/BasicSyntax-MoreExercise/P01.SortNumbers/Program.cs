using System;

namespace P01.SortNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[3];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            Array.Reverse(arr);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
