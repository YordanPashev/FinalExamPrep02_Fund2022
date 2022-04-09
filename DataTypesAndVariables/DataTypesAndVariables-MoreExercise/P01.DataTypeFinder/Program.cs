using System;

namespace P01.DataTypeFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            int valueInt;
            char valueChar;
            bool valueBool;
            float valueFloat;
            while (input != "END")
            {
                if (int.TryParse(input, out valueInt))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (float.TryParse(input, out valueFloat))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (bool.TryParse(input, out valueBool))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else if (char.TryParse(input, out valueChar))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
                input = Console.ReadLine();
            }

        }
    }
}
