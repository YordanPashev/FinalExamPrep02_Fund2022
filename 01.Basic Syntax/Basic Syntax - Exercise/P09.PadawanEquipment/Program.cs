using System;

namespace P09.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var amountOfMoney = double.Parse(Console.ReadLine());
            var students = double.Parse(Console.ReadLine());
            var lightsaberSiglePrice = double.Parse(Console.ReadLine());
            var robeSiglePrice = double.Parse(Console.ReadLine());
            var beltSinglePrice = double.Parse(Console.ReadLine());

            var totalPrice = (Math.Ceiling(students * 1.1)) * lightsaberSiglePrice;
            totalPrice += students * robeSiglePrice;
            totalPrice += (students - Math.Floor(students / 6)) * beltSinglePrice;
            var result = amountOfMoney - totalPrice;
            if (result >= 0)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {Math.Abs(result):F2}lv more.");
            }
        }
    }
}
