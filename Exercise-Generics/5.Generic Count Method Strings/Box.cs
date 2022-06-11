using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Box
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
    {
        private List<T> Elements { get; }
        public T Element { get; }

        public Box(T element)
        {
            Element = element;
        }

        public Box(List<T> elementsList)
        {
            Elements = elementsList;
        }

        public int CountGreaterThanElements<T>(List<T> list, T input) 
            where T : IComparable => list.Count(word => word.CompareTo(input) > 0);

        public void SwapElements(List<T> elementsList, int indexOne, int indexTwo)
        {
            var elementFirst = elementsList[indexOne];
            elementsList[indexOne] = elementsList[indexTwo];
            elementsList[indexTwo] = elementFirst;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var element in Elements)
            {
                sb.AppendLine($"{typeof(T)}: {element}");
            }
            return sb.ToString();
        }

        public int CompareTo(T other) => Element.CompareTo(other);
    }
}

