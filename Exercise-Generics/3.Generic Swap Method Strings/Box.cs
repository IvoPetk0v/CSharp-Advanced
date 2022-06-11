using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Box<T>
    {
        public Box(T element)
        {
            Element = element;
        }
        public Box(List<T> elementsList)
        {
            Elements = elementsList;
        }
        public void SwapElements(List<T> elementsList, int indexOne, int indexTwo)
        {
            var elementFirst = elementsList[indexOne];
            elementsList[indexOne] = elementsList[indexTwo];
            elementsList[indexTwo] = elementFirst;
        }
        private List<T> Elements { get; }
        public T Element { get; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var element in Elements)
            {
                sb.AppendLine($"{typeof(T)}: {element}");
            }
            return sb.ToString();
        }
    }
}

