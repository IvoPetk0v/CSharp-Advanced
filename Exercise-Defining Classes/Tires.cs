﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
  public  class Tires
    {
        public Tires(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }
        public int Age { get; set; }
        public double Pressure { get; set; }

    }
}
