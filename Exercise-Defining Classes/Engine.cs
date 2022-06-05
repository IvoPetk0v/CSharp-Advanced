using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            Displacement = 0;
            Efficiency = null;
        }
        public Engine(string model, int power, int displacement, string efficiency)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }
        public Engine(string model, int power, int displacement)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = null;
        }
        public Engine(string model, int power, string efficiency)
        {
            Model = model;
            Power = power;
            Displacement = 0;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }
        public override string ToString()
        {
            string[] printEngine = new string[4];
            printEngine[0] = $"  {this.Model}:";
            printEngine[1] = $"    Power: {this.Power}";

            if (this.Displacement == 0)
                printEngine[2] = "    Displacement: n/a";
            else
                printEngine[2] = $"    Displacement: { this.Displacement}";

            if (this.Efficiency == null)
                printEngine[3] = "    Efficiency: n/a";
            else
                printEngine[3] = $"    Efficiency: {this.Efficiency}";

            return String.Join(Environment.NewLine, printEngine);
        }
    }
}
