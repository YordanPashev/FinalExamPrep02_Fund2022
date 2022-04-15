using System;

namespace P02.CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(' ');
            string[] arr2 = Console.ReadLine().Split(' ');

            if (arr2.Length > arr1.Length)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    for (int j = 0; j < arr2.Length; j++)
                    {
                        if (arr1[i] == arr2[j])
                        {
                            Console.Write(arr1[i] + " ");
                        }
                    }
                }
            }
            else if (arr1.Length >= arr2.Length)
            {
                for (int i = 0; i < arr2.Length; i++)
                {
                    for (int j = 0; j < arr1.Length; j++)
                    {
                        if (arr2[i] == arr1[j])
                        {
                            Console.Write(arr2[i] + " ");
                        }
                    }
                }
            }
        }
    }
}
