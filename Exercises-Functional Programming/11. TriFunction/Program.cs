using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            
            Func<string, int, bool> isGreaterOrEqual = (name,num)=>name.ToCharArray().Sum(x=>x)>=num;
            Console.WriteLine(names.First(x=>isGreaterOrEqual(x,num)));
            //foreach (var item in names)
            //{
            //    if (isGreaterOrEqual(item,num))
            //    {
            //        Console.WriteLine(item);
            //        break;
            //    }
              
            //}
        }
    }
}
