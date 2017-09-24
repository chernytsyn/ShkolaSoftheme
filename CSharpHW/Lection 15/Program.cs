using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection15_generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var temp1 = new TwoWayListGeneric<int>(1);
            temp1.Add(2);
            temp1.Add(3);
            temp1.Add(4);
            temp1.Add(5);
            temp1.Add(6);
            temp1.Add(7);
            temp1.Add(8);
            temp1.Add(9);
            temp1.Add(10);

            Console.WriteLine("\nLentgh= {0} \n",temp1.Length);
            temp1.PrintList();

            temp1.Delete(1);
            temp1.Delete(7);

            Console.WriteLine("\nLentgh= {0} \n", temp1.Length);
            temp1.PrintList();

            var array = temp1.ToArray();

            Console.WriteLine("\nPrintArray\n");
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
