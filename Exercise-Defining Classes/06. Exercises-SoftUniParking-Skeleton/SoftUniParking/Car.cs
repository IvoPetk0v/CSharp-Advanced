using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    class Car
    {
        public Car(string make, string model, int horsePower, string regNum)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = regNum;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Make: {this.Make}");
            sb.AppendLine();
            sb.Append($"Model: {this.Model}");
            sb.AppendLine();
            sb.Append($"HorsePower: {this.HorsePower}");
            sb.AppendLine();
            sb.Append($"RegistrationNumber: {this.RegistrationNumber}");
            
            return sb.ToString();
        }
    }
}
