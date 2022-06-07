using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;

        public Parking(int capacityData)
        {
            cars = new Dictionary<string, Car>();
            capacity = capacityData;
        }
        public int Count
        {
            get { return cars.Count; }
        }
        public string AddCar(Car car)
        {
            string msg;
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                msg=("Car with that registration number, already exists!");
                return msg;
            }
            else if (cars.Count >= capacity)
            {
               msg="Parking is full!";
                return msg;
            }

            cars.Add(car.RegistrationNumber, car);
            msg=$"Successfully added new car {car.Make} {car.RegistrationNumber}";
            return msg;
        }
        public string RemoveCar(string RegNum)
        {
            string msg;
            if (!cars.ContainsKey(RegNum))
            {
                msg = "Car with that registration number, doesn't exist!";
                return msg;
            }
            cars.Remove(RegNum);
            msg = $"Successfully removed {RegNum}";
            return msg;
        }
        public Car GetCar(string RegNum)
        {
            return cars[RegNum];
        }
        public void RemoveSetOfRegistrationNumber(List<string> regsNums)
        {
            foreach (var regNum in regsNums)
            {
                if (cars.ContainsKey(regNum))
                {
                    cars.Remove(regNum);
                }
            }
            return;
        }
    }
}

