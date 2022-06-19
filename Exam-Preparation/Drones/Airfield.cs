using System;
using System.Collections.Generic;
using System.Linq;

namespace Drones
{
    public class Airfield
    {

        private List<Drone> Drones;
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public double LandingStrip { get; private set; }

        public Airfield(string name, int capacity, double landingStrip)
        {
            Drones = new List<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public int Count
        {
            get { return this.Drones.Count; }
        }
        public string AddDrone(Drone drone)
        {
            if (drone.Name == null || drone.Brand == null || (drone.Range < 5 || drone.Range > 15))
            {
                return "Invalid drone.";
            }
            if (Count + 1 > this.Capacity)
            {
                return "Airfield is full.";
            }
            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            if (Drones.Any(drone => drone.Name == name))
            {
                Drones.RemoveAll(drone => drone.Name == name);
                return true;
            }
            return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            if (Drones.Any(drone => drone.Brand == brand))
            {
                return Drones.RemoveAll(drone => drone.Brand == brand);
            }
            return 0;
        }
        public Drone FlyDrone(string name)
        {
            if (Drones.Any(drone => drone.Name == name))
            {
                Drones.Where(drone => drone.Name == name).ToList().ForEach(drone=>drone.Available=false);
               
                return Drones.Find(drone => drone.Name == name);
            }
            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> resultList = new List<Drone>();
            resultList = Drones.Where(drone => drone.Range >= range).ToList();
            resultList.ForEach(drone => drone.Available = false);
            return resultList;
        }
        public string Report()
        {
            List<Drone> resultList = new List<Drone>();
            resultList = Drones.Where(drone => drone.Available == true).ToList();

            string report = ($"Drones available at {this.Name}:{Environment.NewLine}" + string.Join(Environment.NewLine, resultList));
            return report;
        }
    }
}


