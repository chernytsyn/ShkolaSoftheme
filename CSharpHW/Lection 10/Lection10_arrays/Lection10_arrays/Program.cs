using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lection10_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayInt = new ArrayOperations();

            arrayInt.PrintArray();

            Console.WriteLine("UniqueElement = {0}", arrayInt.UniqueElement);

            Console.WriteLine("Index of unique element = {0}",arrayInt.FindIndexOfUniqueElement());

            Console.ReadLine();
        }
    }
}
