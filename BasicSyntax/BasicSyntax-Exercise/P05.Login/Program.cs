using System;

namespace P05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine();
            var userName = input;
            char[] arr = new char[input.Length];


            for (int i = 0; i < arr.Length; i++)
            {
                char letter = input[i];
                arr[i] = letter;
            }

            Array.Reverse(arr);
            string passwornd = new string(arr);

            input = Console.ReadLine();
            var counter = 1;

            while (input != passwornd && counter < 5)
            {
                if (counter == 4)
                {
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
                input = Console.ReadLine();
                counter++;
            }

            if (input == passwornd)
            {
                Console.WriteLine($"User {userName} logged in.");

            }
            else
            {
                Console.WriteLine($"User {userName} blocked!");
            }
        }
    }
}
