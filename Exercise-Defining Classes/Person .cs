using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public Person()
        {
            name = "No name";
            age = 1;
        }
        public Person(int age)
        {
            name = "No name";
            Age = age;
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public override string ToString()
        {
            return $"{this.name} - {this.age}";
        }
    }
}
