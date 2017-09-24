using System;

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
