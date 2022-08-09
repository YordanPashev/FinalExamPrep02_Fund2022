using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.NeedForSpeed3
{
    internal class Program
    {
        class Car
        {
            public Car(string name, int mileage, int fuel)
            {
                this.Name = name;
                this.Mileage = mileage;
                this.FuelInTheTank = fuel;
            }
            public string Name { get; set; }
            public int Mileage { get; set; }
            public int FuelInTheTank { get; set; }
        }
        static void Main(string[] args)
        {
            List<Car> listOfCars = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfCars; i++)
            {
                AddNewCarToTheList(listOfCars);
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = cmd
                   .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();
                string action = cmdArgs[0];

                if (action == "Drive")
                {
                    TryToDriveTheGivenDistance(cmdArgs, listOfCars);
                }

                else if (action == "Refuel")
                {
                    Refuel(cmdArgs, listOfCars);
                }

                else if (action == "Revert")
                {
                    Revert(cmdArgs, listOfCars);
                }
            }

            DisplayAllCars(listOfCars);
        }

        static void AddNewCarToTheList(List<Car> listOfCars)
        {
            string[] currCarInfo = Console.ReadLine()
                   .Split('|', StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();
            string carName = currCarInfo[0];
            int mileage = int.Parse(currCarInfo[1]);
            int fuelInTheTank = int.Parse(currCarInfo[2]);

            Car currCar = new Car(carName, mileage, fuelInTheTank);
            listOfCars.Add(currCar);
        }

        static void TryToDriveTheGivenDistance(string[] cmdArgs, List<Car> listOfCars)
        {
            string car = cmdArgs[1];
            int distanceToDrive = int.Parse(cmdArgs[2]);
            int neededFuel = int.Parse(cmdArgs[3]);

            var carToDrive = listOfCars.Find(c => c.Name == car);


            if (carToDrive.FuelInTheTank >= neededFuel)
            {
                carToDrive.Mileage += distanceToDrive;
                carToDrive.FuelInTheTank -= neededFuel;
                Console.WriteLine($"{car} driven for {distanceToDrive} kilometers. {neededFuel} liters of fuel consumed.");
            }

            else
            {
                Console.WriteLine($"Not enough fuel to make that ride");
            }

            if (carToDrive.Mileage >= 100000)
            {
                Console.WriteLine($"Time to sell the {carToDrive.Name}!");
                listOfCars.Remove(carToDrive);
            }
        }

        static void Refuel(string[] cmdArgs, List<Car> listOfCars)
        {
            string car = cmdArgs[1];
            int fuelToPut = int.Parse(cmdArgs[2]);

            var carToDrive = listOfCars.Find(c => c.Name == car);
            int addedFuel = fuelToPut;
            int maxFuelPerEachCar = 75;

            if (carToDrive.FuelInTheTank + fuelToPut > 75)
            {
                addedFuel = maxFuelPerEachCar - carToDrive.FuelInTheTank;
                carToDrive.FuelInTheTank = 75;
            }

            else
            {
                carToDrive.FuelInTheTank += fuelToPut;

            }
            Console.WriteLine($"{car} refueled with {addedFuel} liters");
        }

        static void Revert(string[] cmdArgs, List<Car> listOfCars)
        {
            string car = cmdArgs[1];
            int kilometersToRevert = int.Parse(cmdArgs[2]);

            var carToDrive = listOfCars.Find(c => c.Name == car);

            if (carToDrive.Mileage - kilometersToRevert < 10000)
            {
                carToDrive.Mileage = 10000;
            }

            else
            {
                carToDrive.Mileage -= kilometersToRevert;
                Console.WriteLine($"{car} mileage decreased by {kilometersToRevert} kilometers");
            }
        }

        static void DisplayAllCars(List<Car> listOfCars)
        {
            foreach (var car in listOfCars)
            {
                Console.WriteLine($"{car.Name} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.FuelInTheTank} lt.");
            }
        }
    }
}

