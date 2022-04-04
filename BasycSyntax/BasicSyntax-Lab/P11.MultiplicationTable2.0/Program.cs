using System;

namespace P11.MultiplicationTable2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var times = int.Parse(Console.ReadLine());

            for (int i = times; i <= 10; i++)
            {
                Console.WriteLine($"{number} X {i} = {number * i}");
            }

            if (times > 10)
            {
                Console.WriteLine($"{number} X {times} = {number * times}");
            }
        }
    }
}
