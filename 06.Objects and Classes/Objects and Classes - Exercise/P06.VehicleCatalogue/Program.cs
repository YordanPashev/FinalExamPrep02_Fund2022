using System;
using System.Linq;
using System.Collections.Generic;

namespace P06.VehicleCatalogue
{
    class Car
    {
        public Car(string type, string model, string color, int horsePower)
        {
            this.TypeOfVehicle = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }
        public string TypeOfVehicle { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
        public override string ToString()
        {

            return $"Type: Car" + Environment.NewLine +
                   $"Model: {this.Model}" + Environment.NewLine +
                   $"Color: {this.Color}" + Environment.NewLine +
                   $"Horsepower: {this.HorsePower}";
        }
    }

    class Truck
    {
        public Truck(string type, string model, string color, int horsePower)
        {
            this.TypeOfVehicle = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }
        public string TypeOfVehicle { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            return $"Type: Truck" + Environment.NewLine +
                   $"Model: {this.Model}" + Environment.NewLine +
                   $"Color: {this.Color}" + Environment.NewLine +
                   $"Horsepower: {this.HorsePower}";

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            RegisterAllVehicle(cars, trucks);
            PrintWantedViehcleInformation(cars, trucks);
            PrintAverageHorsePowerForEveryType(cars, trucks);
        }

        static void RegisterAllVehicle(List<Car> cars, List<Truck> trucks)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = cmdArgs[0];
                string model = cmdArgs[1];
                string color = cmdArgs[2];
                int horsePower = int.Parse(cmdArgs[3]);

                if (type == "car")
                {
                    Car currCarSpecToAdd = new Car(type, model, color, horsePower);
                    cars.Add(currCarSpecToAdd);

                }

                else if (type == "truck")
                {
                    Truck currTruckSpecToAdd = new Truck(type, model, color, horsePower);
                    trucks.Add(currTruckSpecToAdd);
                }
            }
        }

        static void PrintWantedViehcleInformation(List<Car> cars, List<Truck> trucks)
        {
            string input;

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                string chosenModel = input;
                if (cars.Any(c => c.Model == chosenModel))
                {
                    Car modelNameToFind = cars.Find(c => c.Model == chosenModel);
                    Console.WriteLine(modelNameToFind);
                    continue;
                }

                else if (trucks.Any(t => t.Model == chosenModel))
                {
                    Truck modelNameToFind = trucks.Find(c => c.Model == chosenModel);
                    Console.WriteLine(modelNameToFind);
                    continue;
                }
            }
        }

        static void PrintAverageHorsePowerForEveryType(List<Car> cars, List<Truck> trucks)
        {
            double allCarsHPSum = 0;

            foreach (Car car in cars)
            {
                allCarsHPSum += car.HorsePower;
            }

            double averageCarsHP = 0;

            if (allCarsHPSum != 0)
            {
                averageCarsHP = allCarsHPSum / cars.Count;
            }


            Console.WriteLine($"Cars have average horsepower of: {averageCarsHP:F2}.");

            double allTrucksHPSum = 0;

            foreach (Truck truck in trucks)
            {
                allTrucksHPSum += truck.HorsePower;
            }

            double averageTrucksHP = 0;

            if (allTrucksHPSum != 0)
            {
                averageTrucksHP = allTrucksHPSum / trucks.Count;
            }
            Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHP:F2}.");
        }
    }
}
