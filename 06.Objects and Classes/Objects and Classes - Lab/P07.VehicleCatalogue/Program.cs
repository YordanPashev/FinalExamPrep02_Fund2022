using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.VehicleCatalogue
{
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Car> listOFCars = new List<Car>();
            List<Truck> listOFTrucks = new List<Truck>();


            while ((input = Console.ReadLine()) != "end")
            {
                string[] currentVehicleSpecification = input
                    .Split('/', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = currentVehicleSpecification[0];
                string brand = currentVehicleSpecification[1];
                string model = currentVehicleSpecification[2];

                if (type == "Car")
                {
                    int horsePower = int.Parse(currentVehicleSpecification[3]);
                    Car carSpecification = new Car()
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = horsePower
                    };

                    listOFCars.Add(carSpecification);
                }

                else if (type == "Truck")
                {
                    int truckwWeight = int.Parse(currentVehicleSpecification[3]);

                    Truck truckSpecification = new Truck()
                    {
                        Brand = brand,
                        Model = model,
                        Weight = truckwWeight
                    };

                    listOFTrucks.Add(truckSpecification);
                }
            }

            List<Car> orderedCarList = listOFCars.OrderBy(c => c.Brand).ToList();
            List<Truck> orderedTruckList = listOFTrucks.OrderBy(t => t.Brand).ToList();

            if (orderedCarList.Count != 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in orderedCarList)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (orderedTruckList.Count != 0)
            {
                Console.WriteLine($"Trucks:");
                foreach (var truck in orderedTruckList)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }

    }
}
