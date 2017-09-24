using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection10_arrays_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new ArraySort();

            Console.WriteLine("\n*******************************\n");
            array.PrintArray();

            Console.WriteLine("\n Sorting array \n");
            array.Sort();


            Console.WriteLine("\n*******************************\n");
            array.PrintArray();

            Console.ReadLine();
        }
    }
}
