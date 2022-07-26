using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp41
{
    class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }

        public override string ToString()
        {
            return $"{this.Model}";
        }
    }
    class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }

    class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
        }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            RegisterAllCars(cars);
            PrintTypeOfCargo(cars);
        }

        static void RegisterAllCars(List<Car> cars)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo);
                cars.Add(car);
            }
        }

        static void PrintTypeOfCargo(List<Car> cars)
        {
            string cmd = Console.ReadLine();

            if (cmd == "fragile")
            {
                foreach (Car car in cars.Where(c => c.Cargo.CargoType == "fragile" &&
                                                 c.Cargo.CargoWeight < 1000))
                {
                    Console.WriteLine(car);
                }
            }

            else if (cmd == "flamable")
            {
                foreach (Car car in cars.Where(c => c.Cargo.CargoType == "flamable" &&
                                               c.Engine.EnginePower > 250))
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
