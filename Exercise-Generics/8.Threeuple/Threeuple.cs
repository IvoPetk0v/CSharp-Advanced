using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Threeuple<T1, T2, T3>
    {
        public Threeuple(T1 elementOne, T2 elementTwo, T3 elementTree)
        {
            ElementFirst = elementOne;
            ElementSecond = elementTwo;
            ElementThree = elementTree;
        }
        public T1 ElementFirst { get; set; }
        public T2 ElementSecond { get; set; }
        public T3 ElementThree { get; set; }

        public override string ToString()
        {
            return $"{this.ElementFirst} -> {this.ElementSecond} -> {this.ElementThree}";
        }
    }
}
