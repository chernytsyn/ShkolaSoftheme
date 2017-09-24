using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection10_array_wrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var temp = new int[] {0, 1, 2};

            ArrayWrapper<int> wrappedArray = new ArrayWrapper<int>(temp);

            wrappedArray.PrintArray();

            Console.WriteLine("\n Adding 5 \n");
            wrappedArray.Add(5);

            wrappedArray.PrintArray();
            Console.WriteLine("\n Adding 5 \n");
            wrappedArray.Add(5);
            Console.WriteLine("\n Adding 5 \n");
            wrappedArray.Add(5);
            Console.WriteLine("\n Adding 5 \n");
            wrappedArray.Add(5);

            wrappedArray.PrintArray();

            Console.ReadLine();

        }
    }
}
