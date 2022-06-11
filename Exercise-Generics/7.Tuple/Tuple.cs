using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T1, T2>
    {
        public Tuple(T1 elementOne, T2 elementTwo)
        {
            ElementFirst = elementOne;
            ElementSecond = elementTwo;
        }
        public T1 ElementFirst { get; }
        public T2 ElementSecond { get; }

        public override string ToString()
        {
            return $"{ElementFirst} -> {ElementSecond}";
        }
    }
}
