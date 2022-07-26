using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Car
    {
        public Car(string model, int fuelInTheTank, double fuelConsPerKm)
        {
            this.Model = model;
            this.FuelInTheTank = fuelInTheTank;
            this.FuelConsPerKm = fuelConsPerKm;
            this.TravaledDistance = 0;
        }
        public string Model { get; set; }
        public double FuelInTheTank { get; set; }
        public double FuelConsPerKm { get; set; }
        public int TravaledDistance { get; set; }

        public bool CheckIsThereEnoughFuel(int amountOfKm)
        {
            return (this.FuelInTheTank >= amountOfKm * this.FuelConsPerKm);
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelInTheTank:F2} {this.TravaledDistance}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            RegisterAllCars(cars);
            Drive(cars);
            DisplayAllCarsInfo(cars);
        }

        static void RegisterAllCars(List<Car> cars)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfCars; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = cmdArgs[0];
                int FuelInTheTank = int.Parse(cmdArgs[1]);
                double fuelConsPerKm = double.Parse(cmdArgs[2]);

                Car currCar = new Car(model, FuelInTheTank, fuelConsPerKm);
                cars.Add(currCar);
            }
        }

        static void Drive(List<Car> cars)
        {
            string cmd;

            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = cmdArgs[1];
                int amountOfKm = int.Parse(cmdArgs[2]);

                Car currCar = cars.Find(c => c.Model == model);

                if (currCar.CheckIsThereEnoughFuel(amountOfKm))
                {
                    currCar.TravaledDistance += amountOfKm;
                    currCar.FuelInTheTank -= amountOfKm * currCar.FuelConsPerKm;
                }

                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
        }

        static void DisplayAllCarsInfo(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }  
    }
}
