using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Parking parking = new Parking(5);
            Car car = new Car("Tesla", "Nikola", 300, "AC-DC220");
            Car car1 = new Car("Nikola", "Tesla", 300, "DC-AC220");
            parking.AddCar(car);
            parking.AddCar(car1);
            parking.AddCar(car1);
            parking.RemoveCar("oo");
            parking.GetCar("AC-DC220");
            Console.WriteLine(parking.Count);
            List<String> list = new List<string> { "reg1", "reg" };
            parking.RemoveSetOfRegistrationNumber(list);
            Console.WriteLine(parking.Count);
        }
    }
}